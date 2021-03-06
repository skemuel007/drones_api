using drones_api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using drones_api.Data;
using Autofac;
using drones_api.Helpers;
using Microsoft.AspNetCore.Http.Features;
using Autofac.Extensions.DependencyInjection;
using Hangfire;
using drones_api.Services.Contracts;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace drones_api
{
    public class Startup
    {
        readonly string AllowedOriginSpecifications = "AllowOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add cors to service
            services.AddCors(c =>
            {
                c.AddPolicy(name: AllowedOriginSpecifications, options => options
                .SetIsOriginAllowed(_ => true)
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            // add compression to response
            services.AddResponseCompression();

            // register auto mapper
            services.AddAutoMapper(typeof(Startup));

            // enable api health check
            services.AddHealthChecks();
            services.AddHttpContextAccessor();

            services.AddMemoryCache( options =>
            {
                options.SizeLimit = 1024;
            }
            );

            services.AddResponseCaching( options =>
            {
                // Each response cannot be more than 1 KB 
                options.MaximumBodySize = 1024;

                // Case Sensitive Paths 
                // Responses to be returned only if case sensitive paths match
                options.UseCaseSensitivePaths = true;
            });

            // configure response for web api
            services.AddControllers().AddNewtonsoftJson(
                opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            // configure strongly typed values for appsettings
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure strongly typed settings for cloudinary
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));

            // configure service for file upload
            services.Configure<FormOptions>(f =>
            {
                f.ValueLengthLimit = int.MaxValue;
                f.MultipartBodyLengthLimit = int.MaxValue; // change to defined upload value
                //f.MemoryBufferThreshold = int.MaxValue;
            });

            // Configure Api version
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("api-version")
                   );
            });

            // versioning explorer
            services.AddVersionedApiExplorer(options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());

            // format global json message response
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(e =>
                       e.Value.Errors.Count > 0
                       ).Select(e => new
                       {
                           Error = e.Value.Errors.First().ErrorMessage,
                       }).ToArray();

                    return new BadRequestObjectResult(new
                    {
                        Status = false,
                        Message = errors,
                        Data = new { }
                    });
                };
            });

            services.AddOptions();

            var server = Configuration["DbServer"] ?? "localhost";
            var port = Configuration["DbPort"] ?? "1433"; // Default SQL Server port
            var user = Configuration["DbUser"] ?? "SA"; // Warning do not use the SA account
            var password = Configuration["Password"] ?? "Password@123";
            var database = Configuration["Database"] ?? "DronesDb";

            services.AddDbContext<DronesApiContext>(options =>
                    options.UseSqlServer($"Server={server},{port};Database={database};User Id={user};Password={password}"));
            //services.AddDbContext<DronesApiContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("DronesApiContext")));

            services.AddHangfire(x =>
            {
                // x.UseSqlServerStorage(Configuration.GetConnectionString("DronesApiContext"));
                x.UseSqlServerStorage($"Server={server},{port};Database={database};User ID={user};Password={password}");
            });
            services.AddHangfireServer();
        }
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new ServiceRegistrar());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            DatabaseManagementService.MigrationInitialisation(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        //options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                        options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });

            app.UseMiddleware<GlobalErrorHandler>();

            app.UseRouting();

            app.UseCors(AllowedOriginSpecifications);
            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseMiddleware<RateLimitMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHangfireDashboard("/jobs");

            RecurringJob.AddOrUpdate<ILogRepository>(
                batteryLevelReport => batteryLevelReport.LogDroneBatteryLevel(), Cron.Hourly);

        }
    }
}

using Autofac;
using drones_api.Services.Contracts;
using drones_api.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Middlewares
{
    public class ServiceRegistrar : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<RepositoryManager>().As<IRepositoryManager>();
            builder.RegisterType<PhotoRepository>().As<IPhotoRepository>();
            /*builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces();*/
        }
    }
}

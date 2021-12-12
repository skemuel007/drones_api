# drones_api
## To setup
- Pull the Project from the repo
- If no appsettings, copy appsettings.Development.json to appsettings.json and update the section - DronApiContext with value
```
"Server=db;Database=DronesDb; User=sa;Password=Password@123;"
```

## Running containers
```
docker-compose build
```

Then
```
docker-compose up
```

## To View Running Jobs
Jobs was implemented using asp.net cores hangfire
Visit the base url of the project
```
{baseurl}:{port}/jobs
```
On running jobs, Jobs can be manually triggered by clicking the trigger Jobs - First select a job before you can do this

## To View Logs
Logging was done using Seq

Seq has a splendid support for Serilog's feature such as complex event data, enrichment and structural logging.

After running docker compose as instructed above
Visit the log url
```
http://localhost:5341
```

**Note**: Battery logs are logged as warnings - hence click the warnings link to view hourly battery logs
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /src
COPY ["drones_api.csproj", "./"]
COPY  entrypoint.sh .

RUN dotnet tool install --global dotnet-ef
RUN dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.21

RUN dotnet restore "./drones_api.csproj"
COPY . .
# WORKDIR "/src"

RUN /root/.dotnet/tools/dotnet-ef migrations add InitialMigrations

RUN chmod +x ./entrypoint.sh
CMD /bin/sh ./entrypoint.sh
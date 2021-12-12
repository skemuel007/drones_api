FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /src
COPY ["drones_api.csproj", "./"]
COPY  Setup.sh Setup.sh

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "./drones_api.csproj"
COPY . .
WORKDIR "/src/."

RUN /root/.dotnet/tools/dotnet-ef migrations add InitialMigrations

RUN chmod +x ./Setup.sh
CMD /bin/sh ./Setup.sh
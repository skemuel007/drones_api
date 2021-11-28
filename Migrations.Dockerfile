FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build

WORKDIR /src
COPY ["drones_api.csproj", "./"]
RUN  Setup.sh Setup.sh

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "./drones_api.csproj"
COPY . .
WORKDIR "/src/."

RUN /root/.dotnet/tools/dotnet-ef migrations add InitialMigrations

RUN chmod +x ./Setup.sh
CMD /bin/bash ./Setup.sh
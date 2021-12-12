#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["drones_api.csproj", "./"]

RUN dotnet restore "./drones_api.csproj"
COPY . .
RUN dotnet build "drones_api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "drones_api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "drones_api.dll"]

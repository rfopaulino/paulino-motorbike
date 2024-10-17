# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# COPY *.sln ./
COPY ["src/Paulino.Motorbike.Api/Paulino.Motorbike.Api.csproj", "src/Paulino.Motorbike.Api/"]
COPY ["src/Paulino.Motorbike.Domain/Paulino.Motorbike.Domain.csproj", "src/Paulino.Motorbike.Domain/"]
COPY ["src/Paulino.Motorbike.Infra.CrossCutting.Enum/Paulino.Motorbike.Infra.CrossCutting.Enum.csproj", "src/Paulino.Motorbike.Infra.CrossCutting.Enum/"]
COPY ["src/Paulino.Motorbike.Infra.CrossCutting.EventBus/Paulino.Motorbike.Infra.CrossCutting.EventBus.csproj", "src/Paulino.Motorbike.Infra.CrossCutting.EventBus/"]
COPY ["src/Paulino.Motorbike.Infra.CrossCutting.Exception/Paulino.Motorbike.Infra.CrossCutting.Exception.csproj", "src/Paulino.Motorbike.Infra.CrossCutting.Exception/"]
COPY ["src/Paulino.Motorbike.Infra.CrossCutting.Image/Paulino.Motorbike.Infra.CrossCutting.Image.csproj", "src/Paulino.Motorbike.Infra.CrossCutting.Image/"]
COPY ["src/Paulino.Motorbike.Infra.CrossCutting.Regex/Paulino.Motorbike.Infra.CrossCutting.Regex.csproj", "src/Paulino.Motorbike.Infra.CrossCutting.Regex/"]
COPY ["src/Paulino.Motorbike.Infra.Data/Paulino.Motorbike.Infra.Data.csproj", "src/Paulino.Motorbike.Infra.Data/"]
COPY ["src/Paulino.Motorbike.Infra.Data.Identity/Paulino.Motorbike.Infra.Data.Identity.csproj", "src/Paulino.Motorbike.Infra.Data.Identity/"]
RUN dotnet restore "./src/Paulino.Motorbike.Api/Paulino.Motorbike.Api.csproj"
COPY . .
WORKDIR "/src/src/Paulino.Motorbike.Api"
RUN dotnet build "./Paulino.Motorbike.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Paulino.Motorbike.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Paulino.Motorbike.Api.dll"]
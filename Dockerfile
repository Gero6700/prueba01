FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

#RUN addgroup --system app && adduser --system --ingroup app app

WORKDIR /app

EXPOSE 8080 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

ARG BUILD_CONFIG=Release

# Copiamos solo los .csproj para cachear el restore
COPY ["src/Api/Senator.As400.Cloud.Sync.Api.csproj", "src/Api/"]
COPY ["src/Domain/Senator.As400.Cloud.Sync.Application.csproj", "src/Domain/"]
COPY ["src/Infra/Senator.As400.Cloud.Sync.Infrastructure.csproj","src/Infra/"]
COPY ["Senator.As400.Cloud.Sync.Domain/Senator.As400.Cloud.Sync.Domain.csproj", "Senator.As400.Cloud.Sync.Domain/"]

RUN dotnet restore "src/Api/Senator.As400.Cloud.Sync.Api.csproj"

# Copiamos el resto del código
COPY . .

RUN dotnet build "src/Api/Senator.As400.Cloud.Sync.Api.csproj" -c $BUILD_CONFIG -o /app/build

# Publicamos según el BUILD_CONFIG (Debug / Release)
FROM build AS publish
ARG BUILD_CONFIG=Release
RUN dotnet publish "src/Api/Senator.As400.Cloud.Sync.Api.csproj" \
    -c ${BUILD_CONFIG} -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Asignamos la propiedad de los archivos al usuario no-root
RUN chown -R app:app /app

# Cambiamos al usuario no-root
USER app

ENTRYPOINT ["dotnet", "Senator.As400.Cloud.Sync.Api.dll"]

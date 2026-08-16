# Étape 1: Image de base pour l'exécution
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

# Étape 2: Image pour la compilation (build)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copier le fichier .csproj et restaurer les dépendances
COPY ["CH_Manage.csproj", "./"]
RUN dotnet restore "CH_Manage.csproj"

# Copier tout le reste du code source
COPY . .
WORKDIR "/src"
RUN dotnet build "CH_Manage.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Étape 3: Image pour la publication
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CH_Manage.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Étape 4: Image finale, légère pour la production
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CH_Manage.dll"]

# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy the solution and project files from the build context (solution root).
COPY CH_Manage.sln .
COPY CH_Manage/CH_Manage.csproj CH_Manage/

# Restore dependencies for the entire solution.
RUN dotnet restore CH_Manage.sln

# Copy the rest of the source code.
COPY . .

# Set the working directory to the project folder.
WORKDIR "/src/CH_Manage"

# Publish the application.
RUN dotnet publish "CH_Manage.csproj" -c Release -o /app/publish

# Stage 2: Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published output from the build stage.
COPY --from=build /app/publish .

# Expose port 8080.
EXPOSE 8080

# Define the container's entry point.
ENTRYPOINT ["dotnet", "CH_Manage.dll"]

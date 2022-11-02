# Base Image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy Solution File to support Multi-Project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY fh-family-experience-web.sln ./

# Copy Dependencies
COPY ["src/fh-family-experience-api/fh-family-experience-api.csproj", "src/fh-family-experience-api/"]
COPY ["src/fh-family-experience-core/fh-family-experience-core.csproj", "src/fh-family-experience-core/"]
COPY ["src/fh-family-experience-infrastructure/fh-family-experience-infrastructure.csproj", "src/fh-family-experience-infrastructure/"]
COPY ["src/fh-family-experience-web/fh-family-experience-web.csproj", "src/fh-family-experience-web/"]

# Restore Project
RUN dotnet restore "src/fh-family-experience-web/fh-family-experience-web.csproj"

# Copy Everything
COPY . .

# Build
WORKDIR "/src/src/fh-family-experience-web"
RUN dotnet build "fh-family-experience-web.csproj" -c Release -o /app/build

# publish
FROM build AS publish
WORKDIR "/src/src/fh-family-experience-web"
RUN dotnet publish "fh-family-experience-web.csproj" -c Release -o /app/publish

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "fh-family-experience-web.dll"]

# Export image to tar 
WORKDIR /app/publish
CMD $ docker save --output $(pipeline.workspace)/familyexperienceweb.image.tar $(imagename):$(build.buildid)
# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ProductCatalog.sln ./
COPY ProductCatalog.WebAPI/ProductCatalog.WebAPI.csproj ProductCatalog.WebAPI/
COPY ProductCatalog.Core/ProductCatalog.Core.csproj ProductCatalog.Core/
COPY ProductCatalog.Infrastructure/ProductCatalog.Infrastructure.csproj ProductCatalog.Infrastructure/

# Restore dependencies
RUN dotnet restore ProductCatalog.WebAPI/ProductCatalog.WebAPI.csproj

# Copy the rest of the source code
COPY ProductCatalog.WebAPI/ ProductCatalog.WebAPI/
COPY ProductCatalog.Core/ ProductCatalog.Core/
COPY ProductCatalog.Infrastructure/ ProductCatalog.Infrastructure/

# Build the application
WORKDIR /src/ProductCatalog.WebAPI
RUN dotnet build ProductCatalog.WebAPI.csproj -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish ProductCatalog.WebAPI.csproj -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Create a non-root user (let system assign IDs automatically)
RUN useradd -r -m -s /bin/bash appuser

# Copy published files
COPY --from=publish /app/publish .

# Change ownership
RUN chown -R appuser:appuser /app

# Switch to non-root user
USER appuser

# Expose port 5000
EXPOSE 5000

# Set environment variables
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Production

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
    CMD curl -f http://localhost:5000/health || exit 1

# Run the application
ENTRYPOINT ["dotnet", "ProductCatalog.WebAPI.dll"]

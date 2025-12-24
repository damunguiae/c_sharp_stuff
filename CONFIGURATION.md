# ProductCatalog Configuration Guide

## Overview

This document explains how configuration is managed in the ProductCatalog solution following Clean Architecture principles.

## Configuration Layers

### 1. ProductCatalog.Core (Domain Layer)
- ? **NO Configuration Files**
- Contains only business logic and domain entities
- Zero dependencies on infrastructure or configuration

### 2. ProductCatalog.Infrastructure (Data Access Layer)
- ? **NO Configuration Files**
- Receives configuration via Dependency Injection from WebAPI
- DbContext is configured in the WebAPI's `Program.cs` or `Startup.cs`

### 3. ProductCatalog.WebAPI (Presentation Layer)
- ? **Configuration Files Here**
- `appsettings.json` - Base settings (committed to Git)
- `appsettings.Development.json` - Dev overrides (NOT in Git)
- `appsettings.Production.json` - Prod overrides (in Git, no secrets)

## Configuration Files

### appsettings.json (Base Configuration)
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=productcatalog;Username=postgres;Password=postgres"
  }
}
```
- **Committed to Git**: ? Yes
- **Purpose**: Default settings for all environments
- **Secrets**: Should contain placeholder/default values only

### appsettings.Development.json (Development Overrides)
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.EntityFrameworkCore.Database.Command": "Information"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=productcatalog;Username=postgres;Password=postgres"
  }
}
```
- **Committed to Git**: ? No (in .gitignore)
- **Purpose**: Local development settings
- **Secrets**: Can contain local database passwords

### appsettings.Production.json (Production Overrides)
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Host=postgres;Port=5432;Database=productcatalog;Username=postgres"
  }
}
```
- **Committed to Git**: ? Yes
- **Purpose**: Production settings template
- **Secrets**: ? No passwords - use environment variables instead

## Docker Configuration

### .env File (Docker Compose)
```bash
# Database Configuration
DB_PASSWORD=postgres
POSTGRES_DB=productcatalog
POSTGRES_USER=postgres

# Application Configuration
ASPNETCORE_ENVIRONMENT=Development

# Ports
WEBAPI_PORT=5000
POSTGRES_PORT=5432
```
- **Committed to Git**: ? No (in .gitignore)
- **Purpose**: Environment-specific values for Docker
- **Secrets**: ? Contains passwords and sensitive data
- **?? Warning**: Never commit this file to version control

## Configuration Priority (Highest to Lowest)

1. **Environment Variables** (Highest priority)
   - Set in docker-compose.yml or container runtime
   - Example: `ConnectionStrings__DefaultConnection`

2. **appsettings.{Environment}.json**
   - Environment-specific overrides
   - `ASPNETCORE_ENVIRONMENT` determines which file is loaded

3. **appsettings.json** (Lowest priority)
   - Base configuration
   - Always loaded first

## Accessing Configuration in Code

### In Program.cs (WebAPI)
```csharp
// Read connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure DbContext (Infrastructure layer)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
```

### In Controllers/Services (WebAPI)
```csharp
public class MyController : ControllerBase
{
    private readonly IConfiguration _configuration;
    
    public MyController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IActionResult GetConfig()
    {
        var value = _configuration["SomeKey"];
        return Ok(value);
    }
}
```

## Best Practices

### ? DO:
- Keep Core layer free of configuration
- Inject configuration into Infrastructure from WebAPI
- Use environment variables for secrets in production
- Keep `.env` file out of Git (already in .gitignore)
- Use different connection strings per environment

### ? DON'T:
- Put configuration files in Core or Infrastructure projects
- Commit passwords or secrets to Git
- Commit the `.env` file to version control
- Hardcode connection strings in code
- Share `.env` files with sensitive data

## Environment-Specific Setup

### Local Development (No Docker)
1. Use `appsettings.Development.json`
2. Point to `localhost:5432` for PostgreSQL
3. Run PostgreSQL locally or in Docker

### Docker Development
1. Use `.env` file with docker-compose
2. Connection string uses service name: `Host=postgres`
3. Start with: `docker-compose up -d`

### Production Deployment
1. Set environment variables in container orchestration (Kubernetes, ECS, etc.)
2. Override connection strings via environment variables
3. Never commit production secrets to Git

## Connection String Formats

### Local Development
```
Host=localhost;Port=5432;Database=productcatalog;Username=postgres;Password=postgres
```

### Docker Compose
```
Host=postgres;Port=5432;Database=productcatalog;Username=postgres;Password=${DB_PASSWORD}
```

### Production (Example with SSL)
```
Host=prod-db.example.com;Port=5432;Database=productcatalog;Username=app_user;Password=${DB_PASSWORD};SSL Mode=Require;Trust Server Certificate=true
```

## Troubleshooting

### Connection string not found
```csharp
// Check if connection string exists
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}
```

### Environment not loading correct settings
```bash
# Check which environment is active
echo $ASPNETCORE_ENVIRONMENT  # Linux/Mac
echo %ASPNETCORE_ENVIRONMENT% # Windows

# In docker-compose logs
docker-compose logs webapi | grep "ASPNETCORE_ENVIRONMENT"
```

### Docker can't connect to database
1. Ensure containers are on same network
2. Use service name (not `localhost`) in connection string
3. Wait for database health check before starting API

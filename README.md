# c_sharp_stuff
stuff I test using c#

## ProductCatalog - Clean Architecture

This solution follows Clean Architecture principles with clear separation of concerns and dependency rules.

?? **[Configuration Guide](CONFIGURATION.md)** - Detailed documentation on managing configuration across layers

### Project Structure

```
ProductCatalog/
??? ProductCatalog.Core/           # Domain & Business Logic Layer
??? ProductCatalog.Infrastructure/ # Data Access & External Services Layer
??? ProductCatalog.WebAPI/         # Presentation Layer (API)
```

### Architecture Overview

#### Clean Architecture Dependency Rules

The architecture enforces strict dependency rules to maintain separation of concerns:

```
???????????????????????????????????????????????????
?         ProductCatalog.WebAPI                   ?
?         (Presentation Layer)                    ?
?                                                 ?
?  - Controllers / Endpoints                      ?
?  - DTOs / ViewModels                            ?
?  - Dependency Injection Configuration           ?
???????????????????????????????????????????????????
             ?              ?
             ?              ?
??????????????????????  ????????????????????????????
? ProductCatalog.    ?  ? ProductCatalog.          ?
? Infrastructure     ?  ? Core                     ?
?                    ?  ? (Domain Layer)           ?
? - Repositories     ?  ?                          ?
? - DbContext        ?  ? - Entities               ?
? - External APIs    ?  ? - Interfaces             ?
? - Data Access      ?  ? - Business Logic         ?
??????????????????????  ? - Domain Services        ?
          ?             ?                          ?
          ?             ? **NO DEPENDENCIES**      ?
          ??????????????????????????????????????????
```

### Project Dependencies

#### ? ProductCatalog.Core
- **Dependencies:** NONE
- **Purpose:** Contains the business logic and domain entities
- **Contains:**
  - Domain entities
  - Business interfaces
  - Domain services
  - Business rules and validations

#### ? ProductCatalog.Infrastructure
- **Dependencies:** ProductCatalog.Core
- **Purpose:** Implements infrastructure concerns
- **Contains:**
  - Repository implementations
  - Database context (Entity Framework Core)
  - External service integrations
  - Data access implementations

#### ? ProductCatalog.WebAPI
- **Dependencies:** ProductCatalog.Core, ProductCatalog.Infrastructure
- **Purpose:** API endpoints and presentation logic
- **Contains:**
  - API Controllers / Minimal API endpoints
  - DTOs (Data Transfer Objects)
  - Middleware
  - Dependency injection configuration
  - API-specific configuration

### Key Principles

1. **Dependency Inversion**: High-level modules (Core) don't depend on low-level modules (Infrastructure)
2. **Independence**: Core business logic is independent of frameworks, UI, and databases
3. **Testability**: Each layer can be tested independently
4. **Flexibility**: Easy to swap implementations without affecting business logic

---

## Entity Framework Core Migrations

Quick reference for managing database schema changes using EF Core migrations.

### Prerequisites

Install EF Core tools globally (one-time setup):
```bash
dotnet tool install --global dotnet-ef
```

### Common Commands

All commands should be run from the solution root directory.

#### Create a New Migration

```bash
# Basic migration
dotnet ef migrations add MigrationName --project ProductCatalog.Infrastructure --startup-project ProductCatalog.WebAPI

# With descriptive name (recommended)
dotnet ef migrations add AddProductRatingColumn --project ProductCatalog.Infrastructure --startup-project ProductCatalog.WebAPI
```

#### Apply Migrations

```bash
# Apply all pending migrations to database
dotnet ef database update --project ProductCatalog.Infrastructure --startup-project ProductCatalog.WebAPI

# Apply to specific migration
dotnet ef database update MigrationName --project ProductCatalog.Infrastructure --startup-project ProductCatalog.WebAPI
```

#### Rollback Migrations

```bash
# Rollback to previous migration
dotnet ef database update PreviousMigrationName --project ProductCatalog.Infrastructure --startup-project ProductCatalog.WebAPI

# Rollback all migrations (revert to empty database)
dotnet ef database update 0 --project ProductCatalog.Infrastructure --startup-project ProductCatalog.WebAPI
```

#### Remove Migrations

```bash
# Remove last migration (not yet applied to database)
dotnet ef migrations remove --project ProductCatalog.Infrastructure --startup-project ProductCatalog.WebAPI

# ?? Only works if migration hasn't been applied to any database
```

#### View Migration Information

```bash
# List all migrations
dotnet ef migrations list --project ProductCatalog.Infrastructure --startup-project ProductCatalog.WebAPI

# View migration history in database
dotnet ef migrations has-pending-model-changes --project ProductCatalog.Infrastructure --startup-project ProductCatalog.WebAPI

# Generate SQL script for a migration (preview changes)
dotnet ef migrations script --project ProductCatalog.Infrastructure --startup-project ProductCatalog.WebAPI
```

### Best Practices

1. **Naming Conventions**: Use descriptive names that explain what the migration does
   - ? `AddUserEmailIndex`
   - ? `SeedInitial100Products`
   - ? `Migration1` or `Update`

2. **Before Creating**: Ensure your DbContext changes are complete and tested

3. **Review Generated Code**: Always review the generated migration files before applying

4. **Version Control**: Commit migration files to Git after creation

5. **Production Deployments**: Generate SQL scripts for production rather than running `dotnet ef database update` directly:
   ```bash
   dotnet ef migrations script --project ProductCatalog.Infrastructure --startup-project ProductCatalog.WebAPI --output migration.sql
   ```

### Connection String Configuration

Migrations use the connection string from `ProductCatalog.WebAPI/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=productcatalog;Username=postgres;Password=your_password"
}
```

For Docker environments, ensure the database container is running before applying migrations.

---

## Docker Deployment

The application is containerized using Docker and can be run alongside a PostgreSQL database.

### Configuration Management

#### Clean Architecture Configuration Strategy

Following Clean Architecture principles, configuration is managed at the appropriate layers:

**ProductCatalog.WebAPI** (Presentation Layer):
- `appsettings.json` - Base configuration (committed to Git)
- `appsettings.Development.json` - Development environment settings (ignored by Git)
- `appsettings.Production.json` - Production environment settings (committed to Git, no secrets)
- Connection strings defined here and injected into Infrastructure layer via DI

**ProductCatalog.Infrastructure** (Data Layer):
- Receives DbContext configuration via Dependency Injection
- No direct configuration files - depends on WebAPI layer

**ProductCatalog.Core** (Domain Layer):
- No configuration - pure business logic
- No dependencies on infrastructure or frameworks

#### Environment Variables Setup

**The `.env` file contains your environment configuration:**

Edit `.env` with your values:
```bash
# Database Configuration
DB_PASSWORD=your_secure_password
POSTGRES_DB=productcatalog
POSTGRES_USER=postgres

# Application Configuration
ASPNETCORE_ENVIRONMENT=Development

# Ports
WEBAPI_PORT=5000
POSTGRES_PORT=5432
```

**?? Important:** The `.env` file is ignored by Git to keep secrets safe. Never commit this file to version control.

### Container Architecture

```
???????????????????????????????????????
?   ProductCatalog.WebAPI Container   ?
?   Port: 5000                        ?
?   Image: Custom .NET 10.0           ?
???????????????????????????????????????
               ?
               ? Network: productcatalog-network
               ?
               ?
???????????????????????????????????????
?   PostgreSQL Container              ?
?   Port: 5432                        ?
?   Image: postgres:16-alpine         ?
?   Database: productcatalog          ?
???????????????????????????????????????
```

### Build and Run

#### Using Docker Compose (Recommended)

```bash
# Start both API and PostgreSQL
docker-compose up -d

# View logs
docker-compose logs -f webapi

# Stop containers
docker-compose down

# Stop and remove volumes (data will be lost)
docker-compose down -v
```

#### Using Docker Only

```bash
# Build the image
docker build -t productcatalog-webapi .

# Run the container
docker run -d -p 5000:5000 --name productcatalog-api productcatalog-webapi
```

### Environment Variables

The following environment variables can be configured in the `.env` file:

| Variable | Description | Default | Location |
|----------|-------------|---------|----------|
| `DB_PASSWORD` | PostgreSQL password | `postgres` | `.env` |
| `POSTGRES_DB` | Database name | `productcatalog` | `.env` |
| `POSTGRES_USER` | Database user | `postgres` | `.env` |
| `ASPNETCORE_ENVIRONMENT` | Application environment | `Development` | `.env` |
| `WEBAPI_PORT` | External port for WebAPI | `5000` | `.env` |
| `POSTGRES_PORT` | External port for PostgreSQL | `5432` | `.env` |

**Connection String Format:**
The connection string is automatically built in docker-compose from environment variables:
```
Host=postgres;Port=5432;Database=${POSTGRES_DB};Username=${POSTGRES_USER};Password=${DB_PASSWORD}
```

### Ports

- **WebAPI**: `5000` - Main API endpoint
- **PostgreSQL**: `5432` - Database connection (exposed for development)

### Database Connection String

When running in containers, the connection string format is:

```
Host=postgres;Port=5432;Database=productcatalog;Username=postgres;Password=your_password
```

For local development (without Docker):

```
Host=localhost;Port=5432;Database=productcatalog;Username=postgres;Password=your_password
```

### Health Checks

The API container includes a health check endpoint. You can verify the container health:

```bash
docker ps
# Look for the HEALTH status
```

### Accessing the API

Once running, the API is available at:
- **API Endpoint**: http://localhost:5000
- **OpenAPI/Swagger** (Development): http://localhost:5000/openapi/v1.json

### Troubleshooting

**Container logs:**
```bash
docker logs productcatalog-webapi
docker logs productcatalog-postgres
```

**Access PostgreSQL directly:**
```bash
docker exec -it productcatalog-postgres psql -U postgres -d productcatalog
```

**Rebuild after changes:**
```bash
docker-compose down
docker-compose build --no-cache
docker-compose up -d

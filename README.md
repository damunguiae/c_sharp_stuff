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
```

---

## Docker Compose Cheat Sheet

Quick reference for common Docker Compose commands specific to this project.

### Project Configuration

Your project uses:
- **External Database**: PostgreSQL running outside docker-compose
- **WebAPI Container**: .NET 10.0 application
- **Persistent Logs**: Stored in Docker volume
- **Environment Config**: Via `.env` file

### Essential Commands

#### Build & Start

```bash
# Start services in detached mode
docker-compose up -d

# Start with build (rebuild images)
docker-compose up -d --build

# Build without starting
docker-compose build

# Build with verbose output
docker-compose build --progress=plain --no-cache

# Force rebuild (no cache)
docker-compose build --no-cache
```

#### Stop & Remove

```bash
# Stop containers (keeps data)
docker-compose stop

# Stop and remove containers
docker-compose down

# Stop, remove containers AND volumes (?? deletes logs!)
docker-compose down -v

# Remove specific service
docker-compose rm webapi
```

#### Logs & Monitoring

```bash
# View all logs
docker-compose logs

# Follow logs (real-time)
docker-compose logs -f

# View logs for specific service
docker-compose logs webapi
docker-compose logs -f webapi

# Last 100 lines
docker-compose logs --tail=100 webapi

# Logs with timestamps
docker-compose logs -t webapi
```

#### Container Management

```bash
# List running containers
docker-compose ps

# List all containers (including stopped)
docker-compose ps -a

# Restart services
docker-compose restart

# Restart specific service
docker-compose restart webapi

# Execute command in running container
docker-compose exec webapi bash
docker-compose exec webapi sh

# Run one-off command
docker-compose run webapi dotnet --version
```

#### Health & Status

```bash
# Check container status
docker-compose ps

# View resource usage
docker stats productcatalog-webapi

# Inspect service configuration
docker-compose config

# Validate docker-compose.yml
docker-compose config --quiet
```

### Volume Management

#### View Volumes

```bash
# List all volumes
docker volume ls

# Inspect logs volume
docker volume inspect c_sharp_stuff_logs_data

# Find volume location on host
docker volume inspect c_sharp_stuff_logs_data --format '{{ .Mountpoint }}'
```

#### Access Log Files

```bash
# List log files
docker-compose exec webapi ls -la /app/logs

# View log file
docker-compose exec webapi cat /app/logs/app-20250125.log

# Tail logs in real-time
docker-compose exec webapi tail -f /app/logs/app-20250125.log

# Copy logs to host
docker cp productcatalog-webapi:/app/logs ./logs
```

#### Backup & Restore Logs

```bash
# Backup logs to tar.gz
docker run --rm -v c_sharp_stuff_logs_data:/data -v ${PWD}:/backup alpine tar czf /backup/logs-backup.tar.gz -C /data .

# Restore logs from backup
docker run --rm -v c_sharp_stuff_logs_data:/data -v ${PWD}:/backup alpine tar xzf /backup/logs-backup.tar.gz -C /data

# Clean old logs (older than 30 days)
docker-compose exec webapi find /app/logs -name "*.log" -mtime +30 -delete
```

### Database Connection

#### Connect to External Database

Your setup connects to an external PostgreSQL database. Configuration in `.env`:

```bash
DB_HOST=host.docker.internal  # For database on host machine
# or
DB_HOST=172.17.0.5           # For database in another container (use actual IP)
# or
DB_HOST=postgres-container   # For database in shared Docker network
```

#### Test Database Connection

```bash
# Test connection from WebAPI container
docker-compose exec webapi curl -v http://${DB_HOST}:${POSTGRES_PORT}

# Check environment variables
docker-compose exec webapi printenv | grep -i db
docker-compose exec webapi printenv | grep -i postgres

# Test with psql (if installed in container)
docker-compose exec webapi psql -h ${DB_HOST} -U ${POSTGRES_USER} -d ${POSTGRES_DB}
```

### Debugging

#### View Container Details

```bash
# Inspect container
docker inspect productcatalog-webapi

# View environment variables
docker-compose exec webapi env

# Check network configuration
docker network inspect c_sharp_stuff_default

# View port mappings
docker port productcatalog-webapi
```

#### Shell Access

```bash
# Access container shell (bash)
docker-compose exec webapi bash

# If bash not available, use sh
docker-compose exec webapi sh

# Access as root user
docker-compose exec -u root webapi bash
```

#### Application Debugging

```bash
# Check .NET version
docker-compose exec webapi dotnet --version

# List running processes
docker-compose exec webapi ps aux

# Check listening ports
docker-compose exec webapi netstat -tulpn

# Test API health
curl http://localhost:5000/health
curl http://localhost:5000/api/products
```

### Performance & Optimization

#### Image Management

```bash
# View image size
docker images c_sharp_stuff-webapi

# Remove old images
docker image prune

# Remove all unused images
docker image prune -a

# View image layers
docker history c_sharp_stuff-webapi
```

#### Resource Limits

Add to `docker-compose.yml` if needed:

```yaml
services:
  webapi:
    deploy:
      resources:
        limits:
          cpus: '1'
          memory: 512M
        reservations:
          memory: 256M
```

### Production Deployment

#### Build for Production

```bash
# Build production image
docker-compose build --build-arg ASPNETCORE_ENVIRONMENT=Production

# Tag for registry
docker tag c_sharp_stuff-webapi:latest myregistry/productcatalog:v1.0.0

# Push to registry
docker push myregistry/productcatalog:v1.0.0
```

#### Update Environment

```bash
# Switch to production environment
# Edit .env file:
ASPNETCORE_ENVIRONMENT=Production

# Restart with new environment
docker-compose down
docker-compose up -d
```

### Cleanup

#### Remove Everything

```bash
# Stop and remove containers, networks, volumes
docker-compose down -v

# Remove all stopped containers
docker container prune

# Remove all unused volumes
docker volume prune

# Remove all unused images
docker image prune -a

# Nuclear option: remove everything
docker system prune -a --volumes
```

### Common Workflows

#### Development Workflow

```bash
# 1. Make code changes
# 2. Rebuild and restart
docker-compose up -d --build

# 3. View logs
docker-compose logs -f webapi

# 4. Test changes
curl http://localhost:5000/api/products
```

#### Apply Database Migrations

```bash
# Run migrations from container
docker-compose exec webapi dotnet ef database update --project /src/ProductCatalog.Infrastructure --startup-project /src/ProductCatalog.WebAPI

# Or from host (recommended)
dotnet ef database update --project ProductCatalog.Infrastructure --startup-project ProductCatalog.WebAPI
```

#### Update Dependencies

```bash
# Update NuGet packages
docker-compose down
# Update .csproj files
docker-compose up -d --build
```

### Troubleshooting Common Issues

#### Container Won't Start

```bash
# Check logs
docker-compose logs webapi

# Check configuration
docker-compose config

# Rebuild from scratch
docker-compose down
docker-compose build --no-cache
docker-compose up -d
```

#### Can't Connect to Database

```bash
# Verify DB_HOST setting
docker-compose exec webapi printenv | grep DB_HOST

# Test connectivity
docker-compose exec webapi ping -c 3 ${DB_HOST}

# Check connection string
docker-compose exec webapi printenv | grep ConnectionStrings
```

#### Port Already in Use

```bash
# Find process using port 5000
# Windows:
netstat -ano | findstr :5000

# Linux/Mac:
lsof -i :5000

# Change port in .env
WEBAPI_PORT=5001

# Restart
docker-compose down
docker-compose up -d
```

### Quick Reference Table

| Task | Command |
|------|---------|
| **Start** | `docker-compose up -d` |
| **Stop** | `docker-compose down` |
| **Rebuild** | `docker-compose up -d --build` |
| **Logs** | `docker-compose logs -f webapi` |
| **Shell** | `docker-compose exec webapi bash` |
| **Restart** | `docker-compose restart webapi` |
| **Status** | `docker-compose ps` |
| **Clean Up** | `docker-compose down -v` |

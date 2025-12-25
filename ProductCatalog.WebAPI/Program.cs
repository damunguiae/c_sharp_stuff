using ProductCatalog.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// ============================================
// DEPENDENCY INJECTION CONFIGURATION
// ============================================

// 1. Infrastructure Layer (Data Access)
builder.Services.AddInfrastructureServices(builder.Configuration);

// 2. Core Layer (Business Logic)
builder.Services.AddCoreServices();

// 3. Application Layer (Controllers, CORS, etc.)
builder.Services.AddApplicationServices();

// 4. OpenAPI for API documentation
builder.Services.AddOpenApi();

// ============================================
// MIDDLEWARE PIPELINE
// ============================================

var app = builder.Build();

// Development-specific middleware
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

// Map controllers
app.MapControllers();

// Health check endpoint
app.MapGet("/health", () => Results.Ok(new
{
    status = "Healthy",
    timestamp = DateTime.UtcNow,
    environment = app.Environment.EnvironmentName
}))
.WithName("HealthCheck")
.WithTags("Health");

app.Run();
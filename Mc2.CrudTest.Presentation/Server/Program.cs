using Mc2.CrudTest.Presentation.Server.Repositories;
using Mc2.CrudTest.Presentation.Server.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using Mc2.CrudTest.Presentation.Server.Repositories.Commands;
using Mc2.CrudTest.Presentation.Server.Repositories.Queries;
using Microsoft.EntityFrameworkCore;
using FluentAssertions.Common;
using Mc2.CrudTest.Presentation.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// Registering MVC controllers and views
builder.Services.AddControllersWithViews();
// Registering Razor Pages for server-side rendering
builder.Services.AddRazorPages();


// Registering repositories with dependency injection
builder.Services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
builder.Services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();

// Registering services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IValidationService, ValidationService>();
// Registering MediatR for handling commands and queries
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Configuring the database context with SQL Server
 builder.Services.AddDbContext<DbContextCustomer>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("JouyaTest")));

// Adding endpoints API explorer for API documentation
builder.Services.AddEndpointsApiExplorer();
// Configuring Swagger for API documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer API", Version = "v1" });
});

// Configuring CORS policy to allow all origins, methods, and headers
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging(); // Use Blazor debugging in development
}
else
{
    app.UseExceptionHandler("/Error"); // Global exception handler for production
    app.UseHsts(); // Adds HTTP Strict Transport Security
}

// Common middlewares
app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseBlazorFrameworkFiles(); // Serve Blazor files
app.UseStaticFiles(); // Serve static files
app.UseRouting(); // Enable routing

// Enable CORS
app.UseCors("AllowAllOrigins"); // Use the defined CORS policy

// Enable middleware to serve generated Swagger as a JSON endpoint
app.UseSwagger();

// Enable middleware to serve Swagger UI (HTML, JS, CSS, etc.)
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API V1"); // Specify the Swagger JSON endpoint
    c.RoutePrefix = "swagger"; // Set the route prefix for Swagger UI
});

// Map controllers to API routes
app.MapControllers();
// Map Razor Pages
app.MapRazorPages();
// Fallback to serve the Blazor application
app.MapFallbackToFile("index.html");

// Run the application
app.Run();

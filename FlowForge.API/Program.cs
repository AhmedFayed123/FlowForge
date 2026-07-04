using FlowForge.API.Extensions;
using FlowForge.Application.Common.Behaviors;
using FlowForge.Application.Common.Interfaces;
using FlowForge.Application.Features.Auth.Register;
using FlowForge.Infrastructure.Auth;
using FlowForge.Infrastructure.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FlowForge.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Controllers
        builder.Services.AddControllers();
        builder.Services.AddSwaggerDocumentation();

        // Database
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());

        // MediatR - ÈíÏæÑ Úáì ßá ÇáÜ Handlers Ìæå FlowForge.Application ÊáÞÇÆíðÇ
        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(RegisterCommand).Assembly));

        // Auth Services
        builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
        builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        builder.Services.AddValidatorsFromAssembly(typeof(RegisterCommand).Assembly);
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        // JWT Authentication
        var jwtSecret = builder.Configuration["Jwt:Secret"]!;
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
            };
        });

        builder.Services.AddAuthorization();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerDocumentation();
        }

        app.UseHttpsRedirection();

        // ãåã: ÇáÊÑÊíÈ Ïå áÇÒã íßæä ÈÇáÙÈØ ßÏå
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        // Helpful root endpoint so opening https://localhost:7072/ in a browser doesn't return 404.
        // In Development try redirecting to a UI (if present), otherwise return a short JSON with available endpoints.
        app.MapGet("/", (HttpContext http) =>
        {
            if (app.Environment.IsDevelopment())
            {
                // If Swagger UI is added it commonly lives at /swagger/index.html
                return Results.Redirect("/swagger/index.html");
            }

            return Results.Json(new
            {
                message = "FlowForge API is running.",
                endpoints = new[] { "POST /api/auth/register", "POST /api/auth/login" }
            });
        });

        app.Run();
    }
}
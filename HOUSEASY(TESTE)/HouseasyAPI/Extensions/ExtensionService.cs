using HouseasyBusiness.LoginBusiness;
using HouseasyBusiness.TokenBusiness;
using HouseasyBusiness.UserBusiness;
using HouseasyInfra.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography;

namespace HouseasyAPI.Extensions
{
    public static class ExtensionService
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<ILoginBusiness, LoginBusiness>();
            services.AddTransient<ITokenBusiness, TokenBusiness>();
        }

        public static void ConfigurarSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API - HOUSEASY",
                    Version = "v1",
                    Description = "APIs para atender as demandas referente ao Cadastro"
                });

                c.EnableAnnotations();

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Autenticação JWT",
                    Description = "Informe o Token JWT Bearer **somente**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }

                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, Array.Empty<string>() }
                });
            });
        public static void ConfigurarJWT(this IServiceCollection services)
        {
            Environment.SetEnvironmentVariable("JWT_SECRETO",
                Convert.ToBase64String(new HMACSHA256().Key), EnvironmentVariableTarget.Process);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = "EmitenteDoJWT",
                        ValidAudience = "DestinatarioDoJWT",
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Convert.FromBase64String(Environment.GetEnvironmentVariable("JWT_SECRETO")))
                    };
                });
        }
    }
}

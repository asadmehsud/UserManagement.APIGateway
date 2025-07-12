using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;
using UserManagement.APIGateway.Data;
using UserManagement.APIGateway.Repositories.Implementations;
using UserManagement.APIGateway.Repositories.Interfaces;
using UserManagement.APIGateway.Services.Implementations;
using UserManagement.APIGateway.Services.Interfaces;


namespace UserManagement.APIGateway.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var con = configuration["DefaultConnection"];
            return services.AddDbContext<UserManagementDbContext>(options => options.UseSqlServer("Server=DESKTOP-EQ55Q8H\\SQLEXPRESS;Database=DbUser;TrustServerCertificate=true;Trusted_Connection=True"));
        }

        public static IServiceCollection AddServices(this IServiceCollection services) => services.AddScoped<IUserService, UserService>();
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services.AddScoped<IUserRepository, UserRepository>().AddScoped<IAuthenticationRepository, AuthenticationRepository>().AddScoped<IAuthenticationService, AuthenticationService>();
        public static IServiceCollection AddCustomeSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("vvv", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "User Management Api"
                });
                options.SwaggerDoc("doc2", new OpenApiInfo
                {
                    Version = "Vdoc2",
                    Title = "Asads Api"
                });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the bearer scheme",
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
                var assembly = Assembly.GetExecutingAssembly();
                var xmlFile = $"{assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }
        public static IServiceCollection AddAuthentication(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new()
                   {
                       ValidAudience = configuration["Audience"],
                       ValidIssuer = configuration["Issuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token"]!)),
                       ValidateIssuerSigningKey = true,
                       ValidateLifetime = true,
                   };
               });
            return service;
        }
        public static IConfigurationManager GetJsonFile(this ConfigurationManager configurationManager)
        {
            var configFilePath = Environment.GetEnvironmentVariable("ENV_UserDbConfig", EnvironmentVariableTarget.User);
            if (!string.IsNullOrEmpty(configFilePath) && File.Exists(configFilePath))
            {
                configurationManager.AddJsonFile("D:\\ASP.NET core Web API By Abdullah\\Practice\\UserManagement.APIGateway\\UserManagement.APIGateway\\ConfigFile.json", optional: false, reloadOnChange: true);
            }
            return configurationManager;
        }
        public static IHostBuilder AddSerilog(this IHostBuilder hostBuilder, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            return hostBuilder.UseSerilog();
        }
    }
}

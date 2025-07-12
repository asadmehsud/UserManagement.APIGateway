using FluentValidation;
using FluentValidation.AspNetCore;
using System.ComponentModel.DataAnnotations;
using UserManagement.APIGateway.Extensions;
using UserManagement.APIGateway.Validators.UserValidators;
var builder = WebApplication.CreateBuilder(args);
//Load Json File
builder.Configuration.GetJsonFile();
builder.Services.AddDbContext(builder.Configuration);
//Set Enviroment var

builder.Services.AddServices()
                .AddRepositories()
                .AddCustomeSwagger()
                .AddValidatorsFromAssemblyContaining<UserRegisterDtoValidate>()
                .AddFluentValidationAutoValidation()
                .AddAuthentication(builder.Configuration)
                .AddControllers();
builder.Host.AddSerilog(builder.Configuration);
var app = builder.Build();
app.AddMiddleware();
app.Run();

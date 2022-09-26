using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using test.Business.Interface;
using test.Business.Services;
using test.Infrastructure.Behaviors;
using test.Infrastructure.CQRS.Commands.Request.ProductRequest;
using test.Infrastructure.CQRS.Commands.Response.ProductResponse;
using test.Infrastructure.CQRS.Events.Handler;
using test.Infrastructure.CQRS.Handler.CommandsHandlers.ProductHandler;
using test.Infrastructure.CQRS.Handler.QueryHandlers.ProductQueryHandler;
using test.Infrastructure.CQRS.Handler.TokenHandler;
using test.Infrastructure.Interfaces;
using test.Infrastructure.MongoDB.Interface;
using test.Infrastructure.MongoDB.Setttings;
using test.Infrastructure.Repositories;
using TokenHandler = test.Infrastructure.CQRS.Handler.TokenHandler.TokenHandler;

var builder = WebApplication.CreateBuilder(args);

var productDatabase = builder.Configuration.GetSection(typeof(ProductDatabase).Name).Get<ProductDatabase>();

builder.Services.AddSingleton<IProductDatabase, ProductDatabase>(I => productDatabase);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
// Add services to the container.

builder.Services.AddControllers()
    .AddOData(options => options.Select().Filter().OrderBy().Count().Expand());

builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));




builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();



builder.Services.AddTransient<AddProductCommandHandler>();
builder.Services.AddTransient<GetAllProductQueryHandler>();
builder.Services.AddTransient<DeleteProductCommandHandler>();
builder.Services.AddTransient<UpdateProductCommandHandler>();
builder.Services.AddTransient<GetByIdProductQueryHandler>();
builder.Services.AddTransient<GetMostCheapProductHandler>();
builder.Services.AddTransient<CommandHandler>();

builder.Services.AddTransient<ProductHandler>();
builder.Services.AddScoped<ITokenHandler, TokenHandler>();


builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericManager<,>));

builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<ProductDatabase>(builder.Configuration.GetSection("ProductDatabase"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),

    };
});


builder.Services.AddAuthorization();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddMediatR(typeof(AddProductCommandRequest), typeof(AddProductCommandResponse));
builder.Services.AddDistributedRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

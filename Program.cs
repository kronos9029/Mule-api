using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MuleWebAPIPhatPT19.Business.MapperConfig;
using MuleWebAPIPhatPT19.Business.Services.Interfaces;
using MuleWebAPIPhatPT19.Business.Services;
using MuleWebAPIPhatPT19.Data.Helpers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ok API",
        Description = "API Documentation"
    });
});
builder.Services.AddAutoMapper(typeof(ApplicationMappingProfile));
var ok = builder.Configuration.GetConnectionString("PROD_PHAT");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(ok,
    new MySqlServerVersion(new Version(5, 7, 44))));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
builder.Services.AddScoped<IPurchaseOrderDetailService, PurchaseOrderDetailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

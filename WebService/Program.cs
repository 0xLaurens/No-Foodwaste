using DomainServices.Repos.Inf;
using DomainServices.Services.Impl;
using DomainServices.Services.Inf;
using Infrastructure;
using Infrastructure.Repos.Impl;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

// Reference loop
builder.Services.AddMvc().AddNewtonsoftJson(
    options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });
// FoodDb
builder.Services.AddDbContext<FoodDbContext>(options =>
{
    options
        .UseLazyLoadingProxies()
        .UseSqlServer(
            builder.Configuration.GetConnectionString("FoodDb")
        );
});


// IdentityDb
builder.Services.AddDbContext<AccountDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("IdentityDb")
    );
});
builder.Services.AddScoped<IPackageService, PackageService>();
// Injection (Needs knowledge of Infrastructure)
builder.Services.AddScoped<ICafeteriaRepository, CafeteriaRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IPackageService, PackageService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
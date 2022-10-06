using DomainServices.Repos.Inf;
using Infrastructure;
using Infrastructure.Repos.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// FoodDb
builder.Services.AddDbContext<FoodDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FoodDb")
    );
});


// Injection (Needs knowledge of Infrastructure)
// builder.Services.AddScoped<ICafeteriaRepository, CafeteriaRepository>();
// builder.Services.AddScoped<ICityRepository, CityRepository>();
// builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
// builder.Services.AddScoped<ILocationRepository, LocationRepository>();
// builder.Services.AddScoped<IPackageRepository, PackageRepository>();
// builder.Services.AddScoped<IProductRepository, ProductRepository>();
// builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
using DomainServices.Repos.Inf;
using DomainServices.Services.Impl;
using DomainServices.Services.Inf;
using Infrastructure;
using Infrastructure.Repos.Impl;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

// FoodDb
builder.Services.AddDbContext<FoodDbContext>(options =>
{
    options
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

builder.Services.AddIdentity<IdentityUser, IdentityRole>(
        options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireDigit = true;
        })
    .AddEntityFrameworkStores<AccountDbContext>();

builder.Services.AddAuthorization(options =>
    options.AddPolicy("EmployeeOnly", policy =>
        policy.RequireClaim("Employee")));

builder.Services.AddAuthorization(options =>
    options.AddPolicy("StudentOnly", policy =>
        policy.RequireClaim("Student")));

builder.Services.AddScoped<IPackageService, PackageService>();
// Injection (Needs knowledge of Infrastructure)
builder.Services.AddScoped<ICafeteriaRepository, CafeteriaRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

//Return user to home if trying to access protected page 
builder.Services.ConfigureApplicationCookie(options => { options.AccessDeniedPath = "/"; });


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();
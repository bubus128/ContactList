using ContactList.Business.Services;
using ContactList.Business.Services.Interfaces;
using ContactList.Data.DbContexts;
using ContactList.Data.Repositories;
using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ContactList.Business.MapperProfiles;
using ContactList.Data.Repositories.Interfaces;
using ContactList.Web.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

Env.Load();

builder.Configuration
    .AddEnvironmentVariables();

// Db
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        // Identity settings for simplified testing
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 8;
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login";
    options.LogoutPath = "/Auth/Logout";
});

builder.Services.AddAuthorization();

// Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IContactService, ContactService>();

// AutoMapper
builder.Services.AddAutoMapper(configuration => configuration.AddProfile<BusinessContactProfile>());
builder.Services.AddAutoMapper(configuration => configuration.AddProfile<ViewMapperProfiles>());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHttpsRedirection();

app.Run();

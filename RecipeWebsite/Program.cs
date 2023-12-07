using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Helpers;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Repositories;
using RecipeWebsite.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Project Services

var services = builder.Services;

services.AddControllersWithViews();

// Collection
services.AddScoped<ICollectionInterface, CollectionRepository>();

// Post
services.AddScoped<IPostInterface, PostRepository>();

// Collection Category
services.AddScoped<ICollectionCategoryInterface, CollectionCategoryRepository>();

// Post Category
services.AddScoped<IPostCategoryInterface, PostCategoryRepository>();

// Photo
services.AddScoped<IPhotoInterface, PhotoService>();

var CloudinaryDatabase = builder.Configuration.GetSection("CloudinarySettings");
services.Configure<CloudinarySettingsHelper>(CloudinaryDatabase);

// Database
var MSSQLdatabase = builder.Configuration.GetConnectionString("Database_Connection");
services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(MSSQLdatabase));

// Identity
services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// Email
services.AddTransient<IEmailSenderInterface, EmailSenderService>();

var SMTP_Credentials = builder.Configuration.GetSection("SMTP_Credentials");
services.Configure<EmailHelper>(SMTP_Credentials);

#endregion

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

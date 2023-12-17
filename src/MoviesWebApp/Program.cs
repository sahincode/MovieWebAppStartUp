using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Implementations;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;

using System;
using Westwind.AspNetCore.LiveReload;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorPages(options =>
{

  
    options.Conventions.AddPageRoute("/About", "");
    //options.Conventions.AddPageRoute("", "");

   
    //options.Conventions.AddAreaPageRoute("Admin", "" ,"");


});

builder.Services.AddDbContext<MoviesWebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesWebAppContext") ?? throw new InvalidOperationException("Connection string 'MoviesWebAppContext' not found.")));
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>();
var configuration = builder.Configuration;
///configured services 


builder.Services.Configure<SMTPConfigModel>(configuration.GetSection("SMTPConfig"));

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddAuthentication().AddGoogle(gOptions =>
{
    gOptions.ClientId = configuration["Authentication:Google:ClientId"];
    gOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
    
});


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail
    = true;
}).AddEntityFrameworkStores<MoviesWebAppContext>().AddDefaultTokenProviders();


builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
    options.SignIn.RequireConfirmedAccount = true;
}).
    AddRoles<IdentityRole>().
    AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>>().
    AddEntityFrameworkStores<MoviesWebAppContext>().
    AddDefaultTokenProviders().
    AddDefaultUI();
builder.Services.AddLiveReload();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseLiveReload();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();


app.Run();

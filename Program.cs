using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesWebApp.Data;
using MoviesWebApp.Models.MappingProfiles;
using Westwind.AspNetCore.LiveReload;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddPageRoute("/Logo", "");
    
});

builder.Services.AddDbContext<MoviesWebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesWebAppContext") ?? throw new InvalidOperationException("Connection string 'MoviesWebAppContext' not found.")));




builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedEmail
    = true;
}).AddEntityFrameworkStores<MoviesWebAppContext>();
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

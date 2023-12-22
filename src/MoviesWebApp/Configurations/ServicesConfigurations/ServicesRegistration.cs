using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Implementations;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;
using Westwind.AspNetCore.LiveReload;

namespace MoviesWebApp.Configurations.ServicesConfigurations
{
    public static class ServicesRegistration
    {
        public static void ConfigureServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddLiveReload();
            services.AddAutoMapper(typeof(Program));
            services.AddControllers();
            services.AddRazorPages(options =>
            {
                options.Conventions.AddPageRoute("/About", "");

            });


            //services.AddIdentity<ApplicationUser, IdentityRole>();

            services.AddDbContext<MoviesWebAppContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("MoviesWebAppContext") ?? throw new InvalidOperationException("Connection string 'MoviesWebAppContext' not found.")));
            ///configured services 


            services.Configure<SMTPConfigModel>(configuration.GetSection("SMTPConfig"));

            services.AddScoped<IEmailService, EmailService>();
            services.AddAuthentication().AddGoogle(gOptions =>
            {
                gOptions.ClientId = configuration["Authentication:Google:ClientId"];
                gOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];

            });


            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail
                = true;
            }).AddEntityFrameworkStores<MoviesWebAppContext>().AddDefaultTokenProviders();


            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedAccount = true;
            }).
                AddRoles<IdentityRole>().
                AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>>().
                AddEntityFrameworkStores<MoviesWebAppContext>().
                AddDefaultTokenProviders().
                AddDefaultUI();
        }
    }
}

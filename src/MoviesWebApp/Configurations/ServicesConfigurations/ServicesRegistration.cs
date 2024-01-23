using EpisodesWebApp.Business.Services.Implementations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.DTOs.SettingDTOs;
using MoviesWebApp.Business.MappingProfiles;
using MoviesWebApp.Business.Services.Implementations;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using MoviesWebApp.Data.DAL;
using MoviesWebApp.Data.Repositories.Implementations;
using Westwind.AspNetCore.LiveReload;

namespace MoviesWebApp.Configurations.ServicesConfigurations
{
    public static class ServicesRegistration
    {
        public static void ConfigureServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddLiveReload();
            services.AddAutoMapper(typeof(MapProfile));
            services.AddControllers();
            services.AddRazorPages(options =>
            {
                options.Conventions.AddPageRoute("/About", "");

            }).AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<SettingCreateDtoValidator>();
            });

            services.AddDbContext<MoviesWebAppContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("MoviesWebAppContext") ?? throw new InvalidOperationException("Connection string 'MoviesWebAppContext' not found.")));


            services.Configure<SMTPConfigModel>(configuration.GetSection("SMTPConfig"));
            // services addition
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<ISubscriberService, SubscriberService>();
            services.AddScoped<IPrivacyService, PrivacyService>();
            services.AddScoped<ISerialService, SerialService>();
            services.AddScoped<ISeasonService, SeasonService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IEpisodeService, EpisodeService>();




            services.AddScoped<LayoutService>();
            //repository addition 
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddScoped<IPrivacyRepository, PrivacyRepository>();
            services.AddScoped<ISerialRepository, SerialRepository>();
            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
            services.AddScoped<IEpisodeGenreRepository, EpisodeGenreRepository>();









            //Externa login services addition 
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

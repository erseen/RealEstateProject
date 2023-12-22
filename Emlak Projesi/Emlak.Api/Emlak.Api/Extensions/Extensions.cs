using AutoMapper;
using Emlak.Api.Repository;
using Emlak.Api.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace Emlak.Api.Extensions
{
    public static class Extensions
    {
        public static void RegisterEstateRepository(this IServiceCollection services)
        {
            services.AddScoped<IRealEstateRepository, RealEstateRepository>();
        }
        public static void RegisterRealEstateService(this IServiceCollection services) 
        { 
        services.AddScoped<IRealEstateService,RealEstateManager>(); 
        }
        public static void RegisterWorkPlaceRepository(this IServiceCollection services)
        {
            services.AddScoped<IWorkPlaceRepository,WorkPlaceRepository>();
        }
        public static void RegisterWorkPlaceService(this IServiceCollection services)
        {
            services.AddScoped<IWorkPlaceService, WorkPlaceManager>();
        }
        public static void ConfigureAutoMapper(this IServiceCollection services)
           => services.AddAutoMapper(typeof(Program));

        public static void CorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
              options.AddDefaultPolicy(builder =>
              builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
        }
        public static void RegisterAuthenticationService (this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationManager>();
        }


        public static void ConfigureJwt(this IServiceCollection services,IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                }
            );
        }

        public static void AddNewtonSoft(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
        }
        public static void AddResponseCache(this IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddControllersWithViews(options =>
             options.CacheProfiles.Add("Duration45", new CacheProfile
             {
                 Duration = 45
             })
            );
        }
    }
}

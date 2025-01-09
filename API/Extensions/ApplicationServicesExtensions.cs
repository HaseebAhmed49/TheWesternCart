using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
        {
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultDockerDbConnection"));
            });
            
            services.AddSingleton<IConnectionMultiplexer>(c => 
            {
                var options = ConfigurationOptions.Parse(config.GetConnectionString("Redis"));
                return ConnectionMultiplexer.Connect(options);
            });
            
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            services.AddScoped<IBasketService, BasketService>();
            
            return services;
        }
    }
}
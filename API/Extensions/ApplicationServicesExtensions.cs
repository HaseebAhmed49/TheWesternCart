using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Helpers;
using Application.Interfaces;
using Application.Mapping;
using Application.Services;
using Application.Services.Interfaces;
using Application.UoW;
using Core.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration config
        )
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

            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));

            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            services.AddScoped<IBasketService, BasketService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderHistoryService, OrderHistoryService>();
            services.AddScoped<IWishListService, WishListService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<ILikeDislikeService, LikeDislikeService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IFavouriteItemService, FavouriteItemService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClothingItemService, ClothingItemService>();
            return services;
        }
    }
}
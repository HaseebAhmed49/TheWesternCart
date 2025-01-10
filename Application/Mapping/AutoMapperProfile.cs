using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Extensions;
using Application.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalcuateAge()));
                
            CreateMap<ShippingAddress, AddressDto>().ReverseMap();
            CreateMap<AddressDto, AddressAggregate>();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ClothingItemId, o => o.MapFrom(s => s.ItemOrdered.ClothingItemId))
                .ForMember(d => d.ClothingItemName, o => o.MapFrom(s => s.ItemOrdered.ClothingItemName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
            
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ReverseMap();
            
            CreateMap<Coupon, CouponDto>().ReverseMap();
            
            CreateMap<FavouriteItem, FavouriteItemDto>()
                .ForMember(dest => dest.ClothingItemDto.Name, opt => opt.MapFrom(src => src.ClothingItem.Name))
                .ReverseMap();
            
            CreateMap<LikeDislike, LikeDislikeDto>()
                .ForMember(dest => dest.UserDto.Name, opt => opt.MapFrom(src => src.User.Name))
                .ReverseMap();
            
            CreateMap<Notification, NotificationDto>().ReverseMap();
            
            CreateMap<Rating, RatingDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ReverseMap();
            
            CreateMap<WishList, WishListDto>().ReverseMap();
            CreateMap<WishListItem, WishListItemDto>()
                .ForMember(dest => dest.ClothingItemName, opt => opt.MapFrom(src => src.ClothingItem.Name))
                .ReverseMap();
            
            CreateMap<OrderHistory, OrderHistoryDto>().ReverseMap();
            CreateMap<OrderItemHistory, OrderItemHistoryDto>().ReverseMap();
            
            CreateMap<DateTime, DateTime>().ConvertUsing(d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
            CreateMap<DateTime?, DateTime?>()
                .ConvertUsing(d => d.HasValue ? DateTime.SpecifyKind(d.Value, DateTimeKind.Utc) : null);
        }
        
    }
}
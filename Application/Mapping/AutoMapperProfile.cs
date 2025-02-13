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
                .ForMember(dest => dest.PhotoUrl,
                opt => opt.MapFrom(src => src.UserPhotos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalcuateAge()));

            CreateMap<UserPhoto, UserPhotoDto>();
            CreateMap<UserPhotoDto, UserPhoto>();

            CreateMap<ClothingItem, ClothingItemDto>()
                .ForMember(dest => dest.PictureUrl,
                opt => opt.MapFrom(src => src.ClothingItemPhotos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.ClothingBrand.Name));

            CreateMap<ClothingItemPhoto, ClothingItemPhotoDto>();
            CreateMap<ClothingItemPhotoDto, ClothingItemPhoto>();
                
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
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.MainPictureUrl));
            
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ReverseMap();

            CreateMap<LikeDislike, LikeDislikeDto>()
            .ForPath(dest => dest.UserDto.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ReverseMap();
            
            CreateMap<Coupon, CouponDto>().ReverseMap();
            
            CreateMap<FavouriteItem, FavouriteItemDto>()
                .ForMember(dest => dest.ClothingItemDto, opt => opt.MapFrom(src => src.ClothingItem))
                .ForMember(dest => dest.UserDto, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.ClothingItemDtoId, opt => opt.MapFrom(src => src.ClothingItemId)) 
                .ForMember(dest => dest.UserDtoId, opt => opt.MapFrom(src => src.UserId))
                .ReverseMap();
            
            CreateMap<LikeDislike, LikeDislikeDto>()
                .ForPath(dest => dest.UserDto.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ReverseMap();
            
            CreateMap<Notification, NotificationDto>().ReverseMap();
            
            CreateMap<Rating, RatingDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
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

            CreateMap<ClothingBrand, ClothingBrandDto>().ReverseMap();
        }
        
    }
}
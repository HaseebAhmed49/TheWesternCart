using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Application.Helpers
{
    public class ClothingItemUrlResolver : IValueResolver<ClothingItem, ClothingItemDto, string>
    {
        private readonly IConfiguration _config;

        public ClothingItemUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(
            ClothingItem source,
            ClothingItemDto destination,
            string destMember,
            ResolutionContext context
        )
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}

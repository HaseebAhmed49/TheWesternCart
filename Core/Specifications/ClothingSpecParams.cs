using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Enums;

namespace Core.Specifications
{
    public class ClothingSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 3;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public Guid? ClothingBrandId { get; set; }
        
        public Gender? Gender { get; set; }
        public Size? Size { get; set; }
        public Category? Category { get; set; }

        public string Sort { get; set; } = "name";
        private string _search = "";
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
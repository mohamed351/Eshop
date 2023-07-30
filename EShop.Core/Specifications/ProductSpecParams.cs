﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Core.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public int? BrandID { get; set; }

        public int? TypeID { get; set; }
        public string Sort { get; set; }
        private string _search { get; set; }

        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }

    }
}

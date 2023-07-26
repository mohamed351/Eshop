﻿using System.Collections.Generic;

namespace EShop.API.Helpers
{
    public class Pagination<T> where T:class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int Count { get; set; }

        public IReadOnlyList<T> Data { get; set; }
    }
}

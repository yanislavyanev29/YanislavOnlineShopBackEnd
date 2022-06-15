﻿namespace YanislavOnlineShopBackEnd.RequestHeaders
{
    public class PaginationParams
    {

        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        public int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}

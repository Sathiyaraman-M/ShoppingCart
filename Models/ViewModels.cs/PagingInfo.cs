using System;

namespace ShoppingCart.Models
{
    public class PagingInfo
    {
        public int TotalProducts { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalProducts / ItemsPerPage);
    }
}
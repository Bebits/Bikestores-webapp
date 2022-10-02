using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class cpbModel
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public short ModelYear { get; set; }
        public decimal ListPrice { get; set; }
        public string BrandName { get; set; } 
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public int BrandId { get; set; }

    }
}
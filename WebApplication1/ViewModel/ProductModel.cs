using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class ProductModel
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? quantity { get; set; }
    }
}
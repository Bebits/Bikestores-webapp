using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class  StoreStocksModel
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int? quantity { get; set; }
        public string ProductName { get; set; }
    }
}
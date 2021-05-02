using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InventoryAPI.Models
{
    public class DaywiseCount
    {        
        public long PurchasedCount { get; set; }
        public double PurchasedPrice { get; set; }
        public long SaleCount { get; set; }
        public double SalePrice { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace InventoryAPI.Models
{
    public class SalesProducts
    {        
        public SalesProducts(){
        }

        [Key]
        public long SalesProductId { get; set; }
        [ForeignKey(nameof(Sales))]
        public long SalesId { get; set; }
        [ForeignKey(nameof(Product))]
        public long ProductId { get; set; }
        public long Quantity { get; set; }
        public double SalesPrice { get; set; }
        public double TotalPrice { get; set; }
        public int Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Product Product { get; set; }
    }
}
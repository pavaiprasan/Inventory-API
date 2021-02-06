using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace InventoryAPI.Models
{
    public class PurchaseProducts
    {        
        public PurchaseProducts(){
        }

        [Key]
        public long PurchaseProductId { get; set; }
        [ForeignKey(nameof(Purchase))]
        public long PurchaseId { get; set; }
        [ForeignKey(nameof(Product))]
        public long ProductId { get; set; }
        public long Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public double TotalPrice { get; set; }
        public int Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Product Product { get; set; }
    }
}
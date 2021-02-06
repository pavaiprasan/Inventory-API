using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace InventoryAPI.Models
{
    public class Purchase
    {        
        public Purchase(){
            PurchaseProducts = new HashSet<PurchaseProducts>();
            Payment = new HashSet<Payment>();
        }

        [Key]
        public long PurchaseId { get; set; }
        public string PurchaseNumber { get; set; }
        [ForeignKey(nameof(Supplier))]
        public long SupplierId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public double TotalAmount { get; set; }
        public double BalanceAmount { get; set; }        
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Supplier Supplier { get; set; }
        public ICollection<PurchaseProducts> PurchaseProducts { get; set; }   
        public ICollection<Payment> Payment { get; set; } 
    }
}
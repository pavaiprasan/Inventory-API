using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace InventoryAPI.Models
{
    public class Sales
    {        
        public Sales(){
            SalesProducts = new HashSet<SalesProducts>();
            SalesPayment = new HashSet<SalesPayment>();
        }

        [Key]
        public long SalesId { get; set; }
        public string SalesNumber { get; set; }
        [ForeignKey(nameof(Customer))]
        public long CustomerId { get; set; }
        public DateTime SalesDate { get; set; }
        public int Status { get; set; }        
        public double SalesAmount { get; set; }
        public double TotalAmount { get; set; }
        public double BalanceAmount { get; set; }  
        public double Discount { get; set; }   
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Customer Customer { get; set; }
        public ICollection<SalesProducts> SalesProducts { get; set; }   
        public ICollection<SalesPayment> SalesPayment { get; set; } 
    }
}
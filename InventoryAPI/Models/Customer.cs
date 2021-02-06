using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InventoryAPI.Models
{
    public class Customer
    {        
        [Key]
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int DiscountPercentage { get; set; }
        public int Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
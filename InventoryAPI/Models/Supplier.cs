using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InventoryAPI.Models
{
    public class Supplier
    {        
        [Key]
        public long SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string CompanyName { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
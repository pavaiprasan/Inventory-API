using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace InventoryAPI.Models
{
    public class PaymentType
    {        
        public PaymentType(){
        }

        [Key]
        public long PaymentTypeId { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
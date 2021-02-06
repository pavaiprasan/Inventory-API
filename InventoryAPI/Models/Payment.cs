using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace InventoryAPI.Models
{
    public class Payment
    {        
        public Payment(){
        }

        [Key]
        public long PaymentId { get; set; }
        [ForeignKey(nameof(Purchase))]
        public long PurchaseId { get; set; }
        [ForeignKey(nameof(PaymentType))]
        public long PaymentTypeId { get; set; }
        public double PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
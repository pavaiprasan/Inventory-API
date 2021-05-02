using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace InventoryAPI.Models
{
    public class SalesPayment
    {        
        public SalesPayment(){
        }

        [Key]
        public long SalesPaymentId { get; set; }
        [ForeignKey(nameof(Sales))]
        public long SalesId { get; set; }
        [ForeignKey(nameof(PaymentType))]
        public long PaymentTypeId { get; set; }
        public double PaidAmount { get; set; }
        public DateTime SalesPaymentDate { get; set; }
        public int Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
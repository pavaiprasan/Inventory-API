using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace InventoryAPI.Models
{
    public class Product
    {        
        public Product(){
        }

        [Key]
        public long ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Category))]
        public long CategoryId { get; set; }
        [ForeignKey(nameof(SubCategory))]
        public long SubCategoryId { get; set; }
        public double PurchasePrice { get; set; }
        public double SellingPrice { get; set; }
        public int Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
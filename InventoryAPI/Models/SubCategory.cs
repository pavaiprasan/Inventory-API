using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace InventoryAPI.Models
{
    public class SubCategory
    {        
        public SubCategory(){
        }

        [Key]
        public long SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        [ForeignKey(nameof(Category))]
        public long CategoryId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Category Category { get; set; }
    }
}
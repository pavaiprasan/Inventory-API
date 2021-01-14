using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InventoryAPI.Models
{
    public class SubMenu
    {        
        [Key]
        public long SubMenuId { get; set; }
        public string SubMenuName { get; set; }
        public long MenuId { get; set; }
        public string Route { get; set; }
        public int Status { get; set; }
        public int Order { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
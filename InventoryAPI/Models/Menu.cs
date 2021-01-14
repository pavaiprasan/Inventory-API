using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace InventoryAPI.Models
{
    public class Menu
    {        
        public Menu(){
            SubMenu = new HashSet<SubMenu>();
        }

        [Key]
        public long MenuId { get; set; }
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public string Route { get; set; }
        public int IsSubMenu { get; set; }
        public int Order { get; set; }
        public int Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public ICollection<SubMenu> SubMenu { get; set; }      
    }
}
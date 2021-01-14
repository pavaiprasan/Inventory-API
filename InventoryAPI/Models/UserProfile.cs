using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InventoryAPI.Models
{
    public class UserProfile
    {        
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long Mobile { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        [NotMapped]  
        public string Token { get; set; }      
    }
}
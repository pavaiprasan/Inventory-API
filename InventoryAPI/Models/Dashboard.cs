using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InventoryAPI.Models
{
    public class Dashboard{
        public long CustomerCount { get; set; }
        public long SupplierCount { get; set; }
        public long ProductCount { get; set; }
        public long UserCount { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InventoryAPI.Models
{
    public class CData{
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
    public class ChartData
    {        
        public List<CData> Purchase { get; set; } = new List<CData>();
        public List<CData> Sales { get; set; } = new List<CData>();
    }
}
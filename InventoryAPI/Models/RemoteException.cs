using System;

namespace InventoryAPI.Models
{
    public class RemoteException
    {
        public string message { get; set; }
        public string stackTrace { get; set; }
    }
}
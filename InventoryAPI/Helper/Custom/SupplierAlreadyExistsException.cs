using System;

namespace InventoryAPI.Helper.Custom{

    public class SupplierAlreadyExistsException : Exception
    {
        private static readonly int _code = 462;
        public static string _message = "Supplier Already Exists";
        public SupplierAlreadyExistsException () : base ($"{_code.ToString()} : {_message}"){}
    }
}
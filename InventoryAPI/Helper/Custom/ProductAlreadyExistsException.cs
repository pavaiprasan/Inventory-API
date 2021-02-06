using System;

namespace InventoryAPI.Helper.Custom{

    public class ProductAlreadyExistsException : Exception
    {
        private static readonly int _code = 462;
        public static string _message = "Product Already Exists";
        public ProductAlreadyExistsException () : base ($"{_code.ToString()} : {_message}"){}
    }
}
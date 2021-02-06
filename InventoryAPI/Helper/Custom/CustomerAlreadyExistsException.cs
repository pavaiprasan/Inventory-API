using System;

namespace InventoryAPI.Helper.Custom{

    public class CustomerAlreadyExistsException : Exception
    {
        private static readonly int _code = 462;
        public static string _message = "Customer Already Exists";
        public CustomerAlreadyExistsException () : base ($"{_code.ToString()} : {_message}"){}
    }
}
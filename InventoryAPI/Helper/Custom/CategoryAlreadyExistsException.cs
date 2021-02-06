using System;

namespace InventoryAPI.Helper.Custom{

    public class CategoryAlreadyExistsException : Exception
    {
        private static readonly int _code = 462;
        public static string _message = "Category Already Exists";
        public CategoryAlreadyExistsException () : base ($"{_code.ToString()} : {_message}"){}
    }
}
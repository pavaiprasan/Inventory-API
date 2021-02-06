using System;

namespace InventoryAPI.Helper.Custom{

    public class SubCategoryAlreadyExistsException : Exception
    {
        private static readonly int _code = 462;
        public static string _message = "SubCategory Already Exists";
        public SubCategoryAlreadyExistsException () : base ($"{_code.ToString()} : {_message}"){}
    }
}
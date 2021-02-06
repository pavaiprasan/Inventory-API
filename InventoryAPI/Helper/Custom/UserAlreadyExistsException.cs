using System;

namespace InventoryAPI.Helper.Custom{

    public class UserAlreadyExistsException : Exception
    {
        private static readonly int _code = 462;
        public static string _message = "User Already Exists";
        public UserAlreadyExistsException () : base ($"{_code.ToString()} : {_message}"){}
    }
}
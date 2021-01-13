using System;

namespace InventoryAPI.Helper.Custom{

    public class UserNotFoundException : Exception
    {
        private static readonly int _code = 461;
        public static string _message = "User not Found";
        public UserNotFoundException () : base ($"{_code.ToString()} : {_message}"){}
    }
}
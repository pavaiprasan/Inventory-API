using System;

namespace InventoryAPI.Models
{
    public class RemoteResult<T>
    {
        public T data { get; set; }
        public RemoteException exception { get; set; } = new RemoteException();

        public void SetError(Exception ex)
        {
            if (ex != null)
            {
                exception.message = ex.Message.ToString();
                exception.stackTrace = ex.StackTrace.ToString();
            }
        }
    }
}
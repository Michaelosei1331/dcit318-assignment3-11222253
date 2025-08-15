using System;

namespace Assignment3.Question3_Warehouse
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message) { }
    }
}

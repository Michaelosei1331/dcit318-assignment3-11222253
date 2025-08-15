using System;

namespace Assignment3.Question3_Warehouse
{
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException(string message) : base(message) { }
    }
}

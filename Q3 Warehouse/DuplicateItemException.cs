using System;

namespace Assignment3.Question3_Warehouse
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message) { }
    }
}

using System;

namespace Assignment3.Question4_Grading
{
    public class MissingFieldException : Exception
    {
        public MissingFieldException(string message) : base(message) { }
    }
}

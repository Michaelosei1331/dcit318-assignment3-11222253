using System;

namespace Assignment3.Question4_Grading
{
    public class InvalidScoreFormatException : Exception
    {
        public InvalidScoreFormatException(string message) : base(message) { }
    }
}

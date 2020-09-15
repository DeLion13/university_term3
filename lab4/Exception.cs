using System;

namespace lab3
{
    class ExceptionFind : ArgumentException
    {
        public int Value { get; }
        public ExceptionFind(string message, int val)
            : base(message)
        {
            Value = val;
        }

    }
    
}
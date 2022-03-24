using System;

namespace _29_implementacjaUproszczonegoStosuGenerycznego
{
    internal class StosEmptyException : Exception
    {
        public StosEmptyException()
        { }

        public StosEmptyException(string message) : base(message)
        {
        }

        public StosEmptyException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
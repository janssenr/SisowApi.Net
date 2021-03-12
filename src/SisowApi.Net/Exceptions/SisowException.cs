using System;

namespace SisowApi.Net.Exceptions
{
    public class SisowException : Exception
    {
        public SisowException(string message) : base(message) { }
    }
}

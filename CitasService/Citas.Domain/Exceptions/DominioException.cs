using System;

namespace Citas.Domain.Exceptions
{
    public class DominioException : Exception
    {
        public DominioException() : base() { }
        public DominioException(string mensaje) : base(mensaje) { }
        public DominioException(string mensaje, Exception e) : base(mensaje, e) { }
    }
}

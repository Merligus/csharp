using System;

namespace Exercicio1.Entities.Exceptions
{
    class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {
            Console.WriteLine("No way");
        }
    }
}

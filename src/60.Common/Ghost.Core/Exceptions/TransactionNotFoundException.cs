using System;

namespace Ghost.Core.Exceptions
{
    public class TransactionNotFoundException : Exception
    {
        public TransactionNotFoundException(Type type)
            : base($"Transaction {type.Name} not found.")
        {
            this.Type = type;
        }

        public Type Type { get; private set; }
    }
}
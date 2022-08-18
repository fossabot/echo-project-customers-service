namespace Echo.Customers.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidCustomerIdException : DomainException
    {
        public override string Code { get; }

        public Guid Id { get; }


        public InvalidCustomerIdException(Guid id) : base($"Invalid Customer id: {id}")
            => (Code, Id) = ("invalid_customer_id", id);

        protected InvalidCustomerIdException(SerializationInfo info, StreamingContext context) : base(info, context)
           => (Code, Id) = ("invalid_customer_id", Guid.Empty);
    }
}
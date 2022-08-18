namespace Echo.Customers.Core.Exceptions
{
    using System;

    [Serializable]
    public class InvalidCustomerIdException : DomainException
    {
        public override string Code { get; } = "invalid_customer_id";

        public Guid Id { get; }


        public InvalidCustomerIdException(Guid id) : base($"Invalid Customer id: {id}")
            => Id = id;
    }
}
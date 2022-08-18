namespace Echo.Customers.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class CustomerAddressExistsException : DomainException
    {
        public override string Code { get; } = "customer_address_exists";

        public CustomerAddressExistsException() : base($"Customer address already exists")
            => Code = "customer_address_exists";

        protected CustomerAddressExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
            => Code = "customer_address_exists";
    }
}

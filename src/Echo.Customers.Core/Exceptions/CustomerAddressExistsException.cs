namespace Echo.Customers.Core.Exceptions
{
    using System;

    [Serializable]
    public class CustomerAddressExistsException : DomainException
    {
        public override string Code { get; } = "customer_address_exists";

        public CustomerAddressExistsException() : base($"Customer address already exists") { }
    }
}

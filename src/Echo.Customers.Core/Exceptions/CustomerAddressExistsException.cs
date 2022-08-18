namespace Echo.Customers.Core.Exceptions
{
    using System;
    public class CustomerAddressExistsException : DomainException
    {
        public override string Code { get; } = "customer_address_exists";

        public CustomerAddressExistsException() : base($"Customer address aldready exusts") { }
    }
}

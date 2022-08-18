namespace Echo.Customers.Core.Exceptions
{
    using System;

    public class MissingCustomerAddressException : DomainException
    {
        public override string Code { get; } = "missing_customer_address_list";

        public MissingCustomerAddressException() : base($"Invalid Customer Address List") { }
    }
}

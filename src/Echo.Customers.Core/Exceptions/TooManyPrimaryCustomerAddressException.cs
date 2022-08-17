namespace Echo.Customers.Core.Exceptions
{
    public class TooManyPrimaryCustomerAddressException : DomainException
    {
        public override string Code { get; } = "too_many_primary_addresses";

        public TooManyPrimaryCustomerAddressException() : base($"Too many primary customer addresses defined") { }
    }
}

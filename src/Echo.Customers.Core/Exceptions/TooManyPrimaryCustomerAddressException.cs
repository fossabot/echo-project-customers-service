namespace Echo.Customers.Core.Exceptions
{
    using System.Runtime.Serialization;

    [Serializable]
    public class TooManyPrimaryCustomerAddressException : DomainException
    {
        public override string Code { get; }

        public TooManyPrimaryCustomerAddressException() : base($"Too many primary customer addresses defined")
           => Code = "too_many_primary_addresses";
        protected TooManyPrimaryCustomerAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
            => Code = "too_many_primary_addresses";
    }
}

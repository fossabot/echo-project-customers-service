namespace Echo.Customers.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class MissingCustomerAddressException : DomainException
    {
        public override string Code { get; } 

        public MissingCustomerAddressException() : base($"Invalid Customer Address List")
            => Code = "missing_customer_address_list";

        protected MissingCustomerAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
             => Code = "missing_customer_address_list";
    }
}

namespace Echo.Customers.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class MissingCustomerAddressException : DomainException
    {
        public override string Code { get; }

        public MissingCustomerAddressException() : base($"Missing Customer Address")
            => Code = "missing_customer_address";

        protected MissingCustomerAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
            => Code = info.GetString("Code") ?? "missing_customer_address";

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Code), Code);
            base.GetObjectData(info, context);
        }
    }
}

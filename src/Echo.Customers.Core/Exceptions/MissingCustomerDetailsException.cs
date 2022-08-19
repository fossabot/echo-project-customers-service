namespace Echo.Customers.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class MissingCustomerDetailsException : DomainException
    {
        public override string Code { get; }

        public MissingCustomerDetailsException() : base($"Missing Customer Address")
            => Code = "missing_customer_details";

        protected MissingCustomerDetailsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Code = info.GetString("Code") ?? "missing_customer_details";
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Code), Code);
            base.GetObjectData(info, context);
        }
    }
}

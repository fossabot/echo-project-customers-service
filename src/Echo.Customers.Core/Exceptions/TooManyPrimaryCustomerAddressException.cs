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
        {
            Code = info.GetString("Code") ?? "too_many_primary_addresses";
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(nameof(Code), Code);
            base.GetObjectData(info, context);
        }
    }
}

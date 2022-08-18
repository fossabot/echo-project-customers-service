namespace Echo.Customers.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Linq;

    [Serializable]
    public class CustomerAddressExistsException : DomainException
    {
        public override string Code { get; }

        public CustomerAddressExistsException() : base($"Customer address already exists")
            => Code = "customer_address_exists";


        protected CustomerAddressExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Code = info.GetString(nameof(Code)) ?? "customer_address_exists";
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Code), Code);
            base.GetObjectData(info, context);
        }
    }
}

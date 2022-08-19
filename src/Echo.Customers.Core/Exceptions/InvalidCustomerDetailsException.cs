namespace Echo.Customers.Core.Exceptions
{
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidCustomerDetailsException : DomainException
    {
        public override string Code { get; }

        public string Name { get; }

        public InvalidCustomerDetailsException(string name) : base($"Invalid Customer Details value for {name}")
            => (Code, Name) = ("invalid_customer_details", name);

        protected InvalidCustomerDetailsException(SerializationInfo info, StreamingContext context) : base(info, context)
            => (Code, Name) = (info.GetString(nameof(Code)) ?? "invalid_customer_details", info.GetString(nameof(Name)) ?? "missing_prop_name");

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Code), Code);
            info.AddValue(nameof(Name), Name);
            base.GetObjectData(info, context);
        }
    }
}

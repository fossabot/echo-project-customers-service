namespace Echo.Customers.Core.Exceptions
{
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidCustomerAddressException : DomainException
    {
        public override string Code { get; }

        public string Name { get; }

        public InvalidCustomerAddressException(string name) : base($"Invalid Customer Address value for {name}")
            => (Code, Name) = ("invalid_customer_address", name);

        protected InvalidCustomerAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
            => (Code, Name) = (info.GetString(nameof(Code)) ?? "invalid_customer_address", info.GetString(nameof(Name)) ?? "missing_prop_name");

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Code), Code);
            info.AddValue(nameof(Name), Name);
            base.GetObjectData(info, context);
        }
    }
}

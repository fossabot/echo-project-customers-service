namespace Echo.Customers.Core.Exceptions
{
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidCustomerAddressException : DomainException
    {
        public override string Code { get; }

        public string Name { get; }

        public InvalidCustomerAddressException() : base($"Invalid Customer Address in the List") 
            => (Code, Name) = ("invalid_customer_info", string.Empty);

        public InvalidCustomerAddressException(string name) : base($"Invalid Customer Address for {name}")
            => (Code, Name) = ("invalid_customer_info", name);

        protected InvalidCustomerAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
            => (Code, Name) = ("invalid_customer_info", string.Empty);
    }
}

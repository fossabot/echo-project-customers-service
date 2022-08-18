namespace Echo.Customers.Core.Exceptions
{
    [Serializable]
    public class InvalidCustomerAddressException : DomainException
    {
        public override string Code { get; } = "invalid_customer_info";

        public string Name { get; }

        public InvalidCustomerAddressException() : base($"Invalid Customer Address in the List") 
            => Name = string.Empty;

        public InvalidCustomerAddressException(string name) : base($"Invalid Customer Address for {name}")
            => Name = name;
    }
}

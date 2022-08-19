namespace Echo.Customers.Core.Exceptions
{
    using System.Runtime.Serialization;

    /// <summary>
    /// InvalidCustomerAddressException
    /// </summary>
    /// <seealso cref="Echo.Customers.Core.Exceptions.DomainException" />
    [Serializable]
    public class InvalidCustomerAddressException : DomainException
    {
        /// <summary>
        /// Gets the code.
        /// </summary>
        public override string Code { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCustomerAddressException"/> class.
        /// </summary>
        /// <param name="name"></param>
        public InvalidCustomerAddressException(string name) : base($"Invalid Customer Address, Error: {name}")
            => (Code, Name) = ("invalid_customer_address", name);

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCustomerAddressException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected InvalidCustomerAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
            => (Code, Name) = (info.GetString(nameof(Code)) ?? "invalid_customer_address", info.GetString(nameof(Name)) ?? "missing_prop_name");

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Code), Code);
            info.AddValue(nameof(Name), Name);
            base.GetObjectData(info, context);
        }
    }
}

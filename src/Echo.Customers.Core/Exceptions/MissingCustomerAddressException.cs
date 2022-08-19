namespace Echo.Customers.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// MissingCustomerAddressException
    /// </summary>
    /// <seealso cref="Echo.Customers.Core.Exceptions.DomainException" />
    [Serializable]
    public class MissingCustomerAddressException : DomainException
    {
        /// <summary>
        /// Gets the code.
        /// </summary>
        public override string Code { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingCustomerAddressException"/> class.
        /// </summary>
        public MissingCustomerAddressException() : base($"Missing Customer Address")
            => Code = "missing_customer_address";

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingCustomerAddressException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected MissingCustomerAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
            => Code = info.GetString("Code") ?? "missing_customer_address";

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Code), Code);
            base.GetObjectData(info, context);
        }
    }
}

namespace Echo.Customers.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// InvalidCustomerIdException
    /// </summary>
    /// <seealso cref="Echo.Customers.Core.Exceptions.DomainException" />
    [Serializable]
    public class InvalidCustomerIdException : DomainException
    {
        /// <summary>
        /// Gets the code.
        /// </summary>
        public override string Code { get; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCustomerIdException"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public InvalidCustomerIdException(Guid id) : base($"Invalid Customer id: {id}")
            => (Code, Id) = ("invalid_customer_id", id);

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCustomerIdException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected InvalidCustomerIdException(SerializationInfo info, StreamingContext context) : base(info, context)
            => (Code, Id) = (info.GetString(nameof(Code)) ?? "invalid_customer_id", Guid.Parse(info.GetString(nameof(Id)) ?? Guid.Empty.ToString()));

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Code), Code);
            info.AddValue(nameof(Id), Id);
            base.GetObjectData(info, context);
        }
    }
}
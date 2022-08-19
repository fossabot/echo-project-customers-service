namespace Echo.Customers.Core.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    ///InvalidCustomerException
    /// </summary>
    public class InvalidCustomerException : DomainException
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
        /// Initializes a new instance of the <see cref="InvalidCustomerAccountException"/> class.
        /// </summary>
        /// <param name="name"></param>
        public InvalidCustomerException(string name) : base($"Invalid Customer, Error: {name}")
            => (Code, Name) = ("invalid_customer", name);

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCustomerAccountException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected InvalidCustomerException(SerializationInfo info, StreamingContext context) : base(info, context)
            => (
            Code, Name) = (info.GetString(nameof(Code)) ?? "invalid_customer", info.GetString(nameof(Name)) ?? "missing_prop_name");

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

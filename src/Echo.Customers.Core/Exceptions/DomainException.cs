namespace Echo.Customers.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Linq;

    /// <summary>
    /// Domain Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public abstract class DomainException : Exception
    {
        /// <summary>
        /// Gets the code.
        /// </summary>
        public virtual string Code { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        protected DomainException(string message) : base(message)
        {
            if (string.IsNullOrEmpty(this.Code))
            {
                this.Code = "core_exception";
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
            => Code = "core_exception";
    }
}

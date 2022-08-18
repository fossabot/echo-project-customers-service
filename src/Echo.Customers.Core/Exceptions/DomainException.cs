namespace Echo.Customers.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public abstract class DomainException : Exception
    {
        public virtual string Code { get; }

        protected DomainException(string message) : base(message)
        {
            if (string.IsNullOrEmpty(this.Code))
            {
                this.Code = "core_exception";
            }
        }

        protected DomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}

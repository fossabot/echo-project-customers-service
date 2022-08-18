namespace Echo.Customers.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidCustomerIdException : DomainException
    {
        public override string Code { get; }

        public Guid Id { get; }


        public InvalidCustomerIdException(Guid id) : base($"Invalid Customer id: {id}")
            => (Code, Id) = ("invalid_customer_id", id);

        protected InvalidCustomerIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Code = info.GetString(nameof(Code)) ?? "invalid_customer_id";
            Id = Guid.Parse(info.GetString(nameof(Id)) ?? Guid.Empty.ToString());
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Code), Code);
            info.AddValue(nameof(Id), Id);
            base.GetObjectData(info, context);
        }
    }
}
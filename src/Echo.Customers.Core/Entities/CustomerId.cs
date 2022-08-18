namespace Echo.Customers.Core.Entities
{
    using System;

    using Echo.Customers.Core.Exceptions;

    public class CustomerId : IEquatable<CustomerId>
    {
        public Guid Value { get; }

        public CustomerId() : this(Guid.NewGuid()) { }

        public CustomerId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidCustomerIdException(value);
            }

            Value = value;
        }

        public virtual bool Equals(CustomerId? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return ReferenceEquals(this, other) || Value.Equals(other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == this.GetType() && this.Equals((CustomerId)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
            => Value.ToString();

        public static implicit operator Guid(CustomerId id)
            => id.Value;

        public static implicit operator CustomerId(Guid id)
            => new CustomerId(id);
    }
}

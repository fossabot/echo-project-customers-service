namespace Echo.Customers.Core.Entities
{
    using Echo.Customers.Core.Events;
    using Echo.Customers.Core.Exceptions;
    using Echo.Customers.Core.ValueObjects;

    using System;

    /// <summary>
    /// Customer Domain
    /// </summary>
    /// <seealso cref="CustomerRoot" />
    public class Customer : CustomerRoot, IEquatable<Customer>
    {
        /// <summary>
        /// The customer addresses
        /// </summary>
        private CustomerDetails _details;

        /// <summary>
        /// The customer addresses
        /// </summary>
        private CustomerAddress _address;

        /// <summary>
        /// Gets the customer details.
        /// </summary>
        public CustomerDetails Details
        {
            get => _details;
            private set => _details = value;
        }

        /// <summary>
        /// Gets the customer addresses.
        /// </summary>
        public CustomerAddress Address
        {
            get => _address;
            private set => _address = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customerAddresses">The customer address.</param>
        public Customer(Guid id, CustomerDetails details, CustomerAddress customerAddress)
            : base(id, 0)
        {
            Details = details ?? throw new MissingCustomerDetailsException();
            Address = customerAddress ?? throw new MissingCustomerAddressException();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customerAddresses">The customer addresses.</param>
        /// <param name="version">The version.</param>
        public Customer(Guid id, CustomerDetails details, CustomerAddress customerAddress, int version)
            : base(id, version)
        {
            Details = details ?? throw new MissingCustomerDetailsException();
            Address = customerAddress ?? throw new MissingCustomerAddressException();
        }

        public static Customer Create(Guid id, CustomerDetails details, CustomerAddress customerAddress)
        {
            var customer = new Customer(id, details, customerAddress);
            customer.AddEvent(new CustomerCreated(customer));
            return customer;
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void Delete()
        {
            AddEvent(new CustomerDeleted(this));
        }

        /// <summary>
        /// Gets the equality components.
        /// </summary>
        public IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Details;
            yield return Address;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Customer? other)
        {
            if (other == null || other.GetType() != GetType())
            {
                return false;
            }

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
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

            return obj.GetType() == this.GetType() && this.Equals((Customer)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
            => GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
    }
}
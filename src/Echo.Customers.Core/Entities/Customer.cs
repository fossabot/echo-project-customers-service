namespace Echo.Customers.Core.Entities
{
    using Echo.Customers.Core.Enums;
    using Echo.Customers.Core.Events;
    using Echo.Customers.Core.Exceptions;
    using Echo.Customers.Core.ValueObjects;

    using System;

    /// <summary>
    /// Customer Domain
    /// </summary>
    /// <seealso cref="CustomerBase" />
    public class Customer : CustomerBase, IEquatable<Customer>
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
        /// <param name="customerAddress">The customer address.</param>
        public Customer(Guid id, string name)
            : base(id)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidCustomerDetailsException("Name");
            }

            this.Details = new CustomerDetails(name);
            this.Address = new CustomerAddress();
        }

        /// <summary>Initializes a new instance of the <see cref="Customer" /> class.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="details"></param>
        /// <param name="customerAddress">The customer address.</param>
        /// <param name="version">The version.</param>
        /// <param name="createOn"></param>
        /// <param name="lastUpdate"></param>
        public Customer(Guid id, CustomerDetails details, CustomerAddress customerAddress, int version, CustomerState state, DateTime createOn, DateTime lastUpdate)
            : base(id, version, state, createOn, lastUpdate)
        {
            this.Details = details ?? throw new MissingCustomerDetailsException();
            this.Address = customerAddress ?? throw new MissingCustomerAddressException();
        }

        public static Customer Create(Guid id, string name)
        {
            var customer = new Customer(id, name);
            customer.AddEvent(new CustomerCreated(customer));
            return customer;
        }

        /// <summary>
        /// Set Customer as Incomplete
        /// </summary>
        public void SetIncomplete() => SetState(CustomerState.Incomplete);

        /// <summary>
        /// Activate Customer
        /// </summary>
        public void Activate() => SetState(CustomerState.Active);

        /// <summary>
        /// Suspend Customer
        /// </summary>
        public void Suspend() => SetState(CustomerState.Suspended);

        /// <summary>
        /// Lock Customer
        /// </summary>
        public void Lock() => SetState(CustomerState.Locked);

        /// <summary>
        /// Set Customer as Deleted
        /// </summary>
        public void SoftDelete() => SetState(CustomerState.Deleted);

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void Delete()
        {
            AddEvent(new CustomerDeleted(this));
        }

        public void UpdateCusomerDetails(CustomerDetails details)
        {
            if (details is null)
            {
                throw new MissingCustomerDetailsException();
            }
            if (!details.IsValid())
            {
                throw new InvalidCustomerDetailsException("validation failed");
            }
        }

        /// <summary>
        /// Gets the equality components.
        /// </summary>
        public IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Id;
            yield return this.Details;
            yield return this.Address;
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

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="state">The state.</param>
        private void SetState(CustomerState state)
        {
            var previousState = State;
            this.State = state;
            AddEvent(new CustomerStateChanged(this, previousState));
        }
    }
}
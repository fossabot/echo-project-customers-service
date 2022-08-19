namespace Echo.Customers.Core.Entities
{
    using System;

    using Echo.Customers.Core.Events;
    using Echo.Customers.Core.Exceptions;
    using Echo.Customers.Core.ValueObjects;

    /// <summary>
    /// Customer Domain
    /// </summary>
    /// <seealso cref="CustomerRoot" />
    public class Customer : CustomerRoot
    {
        /// <summary>
        /// The customer addresses
        /// </summary>
        private CustomerAddress _address;

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
        public Customer(Guid id, CustomerAddress? customerAddress)
            : base(id, 0)
        {
            Address = customerAddress ?? throw new MissingCustomerAddressException();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customerAddresses">The customer addresses.</param>
        /// <param name="version">The version.</param>
        public Customer(Guid id, CustomerAddress customerAddress, int version)
            : base(id, version)
        {
            Address = customerAddress ?? throw new MissingCustomerAddressException();
        }

        public static Customer Create(Guid id, CustomerAddress customerAddress)
        {
            var customer = new Customer(id, customerAddress);
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
    }
}

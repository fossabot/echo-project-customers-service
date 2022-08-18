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
        private IEnumerable<CustomerAddress> _customerAddresses;

        /// <summary>
        /// Gets the customer addresses.
        /// </summary>
        public IEnumerable<CustomerAddress> CustomerAddresses
        {
            get => _customerAddresses;
            private set => _customerAddresses = new List<CustomerAddress>(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customerAddresses">The customer addresses.</param>
        public Customer(Guid id, IEnumerable<CustomerAddress> customerAddresses)
            : base(id, 0)
        {
            ValidateAdresses(customerAddresses);
            CustomerAddresses = customerAddresses;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customerAddresses">The customer addresses.</param>
        /// <param name="version">The version.</param>
        public Customer(Guid id, IEnumerable<CustomerAddress> customerAddresses, int version)
            : base(id, version)
        {
            ValidateAdresses(customerAddresses);
            CustomerAddresses = customerAddresses;
        }

        public static Customer Create(Guid id, IEnumerable<CustomerAddress> customerAddresses)
        {
            var customer = new Customer(id, customerAddresses);
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
        /// Validates the addresses.
        /// </summary>
        /// <param name="customerAddresses">The customer addresses.</param>
        /// <exception cref="MissingCustomerAddressException"></exception>
        /// <exception cref="InvalidCustomerAddressException"></exception>
        /// <exception cref="TooManyPrimaryCustomerAddressException"></exception>
        private static void ValidateAdresses(IEnumerable<CustomerAddress> customerAddresses)
        {
            if (customerAddresses is null)
            {
                throw new MissingCustomerAddressException();
            }
            else if (customerAddresses.Any(x => x is null))
            {
                throw new InvalidCustomerAddressException();
            }
            else if (customerAddresses.Count(x => x.IsPrimary) > 1)
            {
                throw new TooManyPrimaryCustomerAddressException();
            }
        }
    }
}

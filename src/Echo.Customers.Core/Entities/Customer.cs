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
        private IList<CustomerAddress> _addresses;

        /// <summary>
        /// Gets the customer addresses.
        /// </summary>
        public IEnumerable<CustomerAddress> Addresses
        {
            get => _addresses;
            private set => _addresses = new List<CustomerAddress>(value);
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
            Addresses = customerAddresses;
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
            Addresses = customerAddresses;
        }

        public static Customer Create(Guid id, IEnumerable<CustomerAddress> customerAddresses)
        {
            var customer = new Customer(id, customerAddresses);
            customer.AddEvent(new CustomerCreated(customer));
            return customer;
        }

        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <exception cref="Echo.Customers.Core.Exceptions.InvalidCustomerAddressException"></exception>
        /// <exception cref="Echo.Customers.Core.Exceptions.TooManyPrimaryCustomerAddressException"></exception>
        public void AddAddress(CustomerAddress address)
        {
            if (address is null)
            {
                throw new InvalidCustomerAddressException();
            }
            else if (address.IsPrimary && Addresses.Count(x => x.IsPrimary) == 1)
            {
                throw new TooManyPrimaryCustomerAddressException();
            }

            _addresses.Add(address);
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

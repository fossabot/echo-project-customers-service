﻿namespace Echo.Customers.Core.Events
{
    using Echo.Customers.Core.Contracts;
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.ValueObjects;

    /// <summary>
    /// Customer Details Changed event
    /// </summary>
    /// <seealso cref="Echo.Customers.Core.Contracts.IDomainEvent" />
    public class CustomerDetailsChanged : IDomainEvent
    {
        /// <summary>
        /// Gets the customer.
        /// </summary>
        public Customer Customer { get; }

        /// <summary>
        /// Gets the state of the previous.
        /// </summary>
        public CustomerDetails Previous { get; }

        /// <summary>Initializes a new instance of the <see cref="CustomerDetailsChanged" /> class.</summary>
        /// <param name="customer">The customer.</param>
        /// <param name="previous"></param>
        public CustomerDetailsChanged(Customer customer, CustomerDetails previous)
            => (Customer, Previous) = (customer, previous);
    }
}

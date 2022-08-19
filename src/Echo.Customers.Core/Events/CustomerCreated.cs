namespace Echo.Customers.Core.Events
{
    using Echo.Customers.Core.Contracts;
    using Echo.Customers.Core.Entities;

    /// <summary>
    /// Customer Created event
    /// </summary>
    /// <seealso cref="Echo.Customers.Core.Contracts.IDomainEvent" />
    public class CustomerCreated : IDomainEvent
    {
        /// <summary>
        /// Gets the customer.
        /// </summary>
        public Customer Customer { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCreated"/> class.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public CustomerCreated(Customer customer)
            => Customer = customer;
    }
}

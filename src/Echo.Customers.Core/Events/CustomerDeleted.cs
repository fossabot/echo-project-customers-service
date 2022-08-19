namespace Echo.Customers.Core.Events
{
    using Echo.Customers.Core.Contracts;
    using Echo.Customers.Core.Entities;

    /// <summary>
    /// Customer Deleted event
    /// </summary>
    /// <seealso cref="Echo.Customers.Core.Contracts.IDomainEvent" />
    public class CustomerDeleted : IDomainEvent
    {
        /// <summary>
        /// Gets the customer.
        /// </summary>
        public Customer Customer { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDeleted"/> class.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public CustomerDeleted(Customer customer)
            => Customer = customer;
    }
}

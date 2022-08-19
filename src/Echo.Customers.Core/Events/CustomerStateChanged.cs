namespace Echo.Customers.Core.Events
{
    using Echo.Customers.Core.Contracts;
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.Enums;

    /// <summary>
    /// Customer State Changed event
    /// </summary>
    /// <seealso cref="Echo.Customers.Core.Contracts.IDomainEvent" />
    public class CustomerStateChanged : IDomainEvent
    {
        /// <summary>
        /// Gets the customer.
        /// </summary>
        public Customer Customer { get; }

        /// <summary>
        /// Gets the state of the previous.
        /// </summary>
        public CustomerState PreviousState { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerStateChanged"/> class.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="previousState">State of the previous.</param>
        public CustomerStateChanged(Customer customer, CustomerState previousState)
            => (Customer, PreviousState) = (customer, previousState);
    }
}

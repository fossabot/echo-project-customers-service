namespace Echo.Customers.Core.Events
{
    using Echo.Customers.Core.Contracts;
    using Echo.Customers.Core.Entities;

    public class CustomerDeleted : IDomainEvent
    {
        public Customer Customer { get; }

        public CustomerDeleted(Customer customer)
            => Customer = customer;
    }
}

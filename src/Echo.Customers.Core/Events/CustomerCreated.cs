namespace Echo.Customers.Core.Events
{
    using Echo.Customers.Core.Contracts;
    using Echo.Customers.Core.Entities;

    public class CustomerCreated : IDomainEvent
    {
        public Customer Customer { get; }

        public CustomerCreated(Customer customer)
            => Customer = customer;
    }
}

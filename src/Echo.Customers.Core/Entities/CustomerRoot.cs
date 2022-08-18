namespace Echo.Customers.Core.Entities
{
    using Echo.Customers.Core.Contracts;
    using Echo.Customers.Core.Exceptions;

    public abstract class CustomerRoot
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();

        public CustomerId Id
        {
            get; protected set;
        }

        public int Version { get; protected set; }

        public IEnumerable<IDomainEvent> Events => _events;

        protected CustomerRoot(Guid id, int version)
        {
            this.Id = id;
            this.Version = version;
        }

        protected void AddEvent(IDomainEvent @event)
        {
            if (!_events.Any())
            {
                Version++;
            }

            _events.Add(@event);
        }

        public void ClearEvents() => _events.Clear();
    }
}

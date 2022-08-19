﻿namespace Echo.Customers.Core.Entities
{
    using Echo.Customers.Core.Contracts;
    using Echo.Customers.Core.Enums;
    using Echo.Customers.Core.Exceptions;

    /// <summary>
    /// Customer Base class
    /// </summary>
    public abstract class CustomerBase
    {
        /// <summary>
        /// The Customer events
        /// </summary>
        private readonly IList<IDomainEvent> _events = new List<IDomainEvent>();

        /// <summary>
        /// Gets or sets the Customer identifier.
        /// </summary>
        public CustomerId Id
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the Customer version.
        /// </summary>
        public int Version { get; protected set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public CustomerState State { get; protected set; }

        /// <summary>
        /// Gets the Customer events.
        /// </summary>
        public IEnumerable<IDomainEvent> Events => _events;

        /// <summary>
        /// Gets the create on date.
        /// </summary>
        public DateTime CreateOn { get; init; }

        /// <summary>
        /// Gets the last update date.
        /// </summary>
        public DateTime LastUpdate { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerBase"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected CustomerBase(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                throw new InvalidCustomerIdException(id);
            }

            this.Id = id;
            this.Version = 0;
            this.State = CustomerState.Incomplete;
            this.CreateOn = DateTime.UtcNow;
            this.LastUpdate = DateTime.UtcNow;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerBase"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="version">The version.</param>
        /// <param name="createOn">The create on.</param>
        /// <param name="lastUpdate">The last update.</param>
        protected CustomerBase(Guid id, int version, CustomerState state, DateTime createOn, DateTime lastUpdate)
        {
            if (id.Equals(Guid.Empty))
            {
                throw new InvalidCustomerIdException(id);
            }

            this.Id = id;
            this.Version = version < 0 ? throw new InvalidCustomerException(nameof(this.Version)) : version;
            this.State = state == CustomerState.Unknown ? throw new InvalidCustomerException(nameof(this.State)) : state;
            this.CreateOn = createOn;
            this.LastUpdate = lastUpdate;
        }

        /// <summary>
        /// Adds a event.
        /// </summary>
        /// <param name="event">The event.</param>
        protected void AddEvent(IDomainEvent @event)
        {
            if (!_events.Any())
            {
                Version++;
            }

            _events.Add(@event);
        }

        /// <summary>
        /// Clears the events.
        /// </summary>
        public void ClearEvents() => _events.Clear();
    }
}
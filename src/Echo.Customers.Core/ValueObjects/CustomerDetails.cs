namespace Echo.Customers.Core.ValueObjects
{
    using Echo.Customers.Core.Exceptions;

    using System.Collections.Generic;

    /// <summary>
    /// Customer Details Value Object
    /// </summary>
    /// <seealso cref="Echo.Customers.Core.ValueObjects.ValueObject" />
    public class CustomerDetails : ValueObject
    {
        /// <summary>
        /// Gets or sets the Customer name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Customer tenant string.
        /// </summary>
        public string Tenant { get; set; }

        /// <summary>
        /// Gets or sets the Customer billing account.
        /// </summary>
        public Guid BillingAccount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDetails"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="Echo.Customers.Core.Exceptions.InvalidCustomerDetailsException">Name</exception>
        public CustomerDetails(string name)
        {
            Name = name ?? throw new InvalidCustomerDetailsException(nameof(Name));
            Tenant = Guid.NewGuid().ToString();
            BillingAccount = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDetails"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="tenant">The tenant.</param>
        /// <param name="billingAccount">The billing account.</param>
        /// <exception cref="Echo.Customers.Core.Exceptions.InvalidCustomerDetailsException"></exception>
        public CustomerDetails(string name, string tenant, Guid billingAccount)
        {
            Name = name ?? throw new InvalidCustomerDetailsException(nameof(Name));
            Tenant = tenant ?? throw new InvalidCustomerDetailsException(nameof(Tenant));
            BillingAccount = billingAccount.Equals(Guid.Empty)
                ? throw new InvalidCustomerDetailsException(nameof(BillingAccount))
                : billingAccount;
        }

        /// <summary>
        /// Returns true if Customer Details is valid.
        /// </summary>
        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(this.Name)
                && !string.IsNullOrWhiteSpace(this.Name)
                && !string.IsNullOrEmpty(this.Tenant)
                && !string.IsNullOrWhiteSpace(this.Tenant)
                && !this.Tenant.Equals(Guid.Empty);
        }

        /// <summary>
        /// Gets the equality components.
        /// </summary>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Tenant;
            yield return BillingAccount;
        }
    }
}

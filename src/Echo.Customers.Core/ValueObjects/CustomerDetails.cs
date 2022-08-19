namespace Echo.Customers.Core.ValueObjects
{
    using Echo.Customers.Core.Exceptions;

    using System.Collections.Generic;

    public class CustomerDetails : ValueObject
    {
        public string Name { get; set; }

        public string Tenant { get; set; }

        public Guid Owner { get; set; }

        public CustomerDetails(string name, string tenant)
        {
            Name = name ?? throw new InvalidCustomerDetailsException(nameof(Name));
            Tenant = tenant ?? throw new InvalidCustomerDetailsException(nameof(Tenant));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Tenant;
            yield return Owner;
        }
    }
}

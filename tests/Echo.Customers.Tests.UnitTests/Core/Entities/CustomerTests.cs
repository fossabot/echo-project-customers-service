namespace Echo.Customers.Tests.UnitTests.Core.Entities
{
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.ValueObjects;

    using Shouldly;

    using Xunit;

    public partial class CustomerTests
    {
        // Arrange
        private static readonly CustomerId id = new CustomerId();
        private static readonly CustomerDetails details = new CustomerDetails("Name", "Tenant");
        private static readonly CustomerAddress address = new CustomerAddress("Country", "City", 12345, "address");
        private static readonly Customer customer = Customer.Create(id, details, address);

        [Fact]
        public void Hash_Customer_Should_Be_Created()
        {
            //Act
            int hash = customer.GetHashCode();

            //Assert
            hash.ShouldNotBe(0);
        }
    }
}

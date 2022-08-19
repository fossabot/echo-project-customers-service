namespace Echo.Customers.Tests.UnitTests.Core.Entities
{
    using System.Linq;

    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.Events;
    using Echo.Customers.Core.Exceptions;
    using Echo.Customers.Core.ValueObjects;

    using Shouldly;

    using Xunit;

    public class DeleteCustomerTests
    {
        // Arrange
        private static readonly CustomerId id = new CustomerId();
        private static readonly CustomerDetails details = new CustomerDetails("Name", "Tenant");
        private static readonly CustomerAddress address = new CustomerAddress("Country", "City", 12345, "address");
        private static readonly Customer customer = Customer.Create(id, details, address);

        [Fact]
        public void Customer_Should_Be_Deleted()
        {
            // Act
            customer.Delete();

            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(id);
            customer.Events.Count().ShouldBe(2);

            var @event = customer.Events.Last();
            @event.ShouldBeOfType<CustomerDeleted>();
            ((CustomerDeleted)@event).Customer.ShouldNotBeNull();
            ((CustomerDeleted)@event).Customer.Equals(customer).ShouldBeTrue();
        }
    }
}

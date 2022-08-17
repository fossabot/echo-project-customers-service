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
        [Fact]
        public void Given_Valid_Values_Customer_Should_Be_Deleted()
        {
            // Arrange
            CustomerId id = new CustomerId();
            List<CustomerAddress> addresses = new List<CustomerAddress>
                { 
                    new CustomerAddress("Country", "City", 12345, "address")
                };

            Customer resource = Customer.Create(id, addresses);

            // Act
            resource.Delete();

            // Assert
            resource.ShouldNotBeNull();
            resource.Id.ShouldBe(id);
            resource.Events.Count().ShouldBe(2);

            var @event = resource.Events.Last();
            @event.ShouldBeOfType<CustomerDeleted>();
        }
    }
}

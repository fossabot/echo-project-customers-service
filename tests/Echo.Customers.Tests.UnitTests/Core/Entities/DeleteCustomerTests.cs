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
        public void Customer_Should_Be_Deleted()
        {
            // Arrange
            CustomerId id = new CustomerId();
            CustomerAddress address = new CustomerAddress("Country", "City", 12345, "address");

            Customer customer = Customer.Create(id, address);

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

        [Fact]
        public void Events_Should_Be_Deleted()
        {
            // Arrange
            CustomerId id = new CustomerId();
            CustomerAddress address = new CustomerAddress("Country", "City", 12345, "address");


            Customer customer = Customer.Create(id, address);

            // Act
            customer.Delete();

            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(id);
            customer.Events.Count().ShouldBe(2);
            customer.ClearEvents();
            customer.Events.Count().ShouldBe(0);
        }
    }
}

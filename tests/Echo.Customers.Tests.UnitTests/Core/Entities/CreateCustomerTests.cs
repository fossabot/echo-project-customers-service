namespace Echo.Customers.Tests.UnitTests.Core.Entities
{
    using System.Linq;

    using Echo.Customers.Core.Contracts;
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.Events;
    using Echo.Customers.Core.Exceptions;
    using Echo.Customers.Core.ValueObjects;

    using Shouldly;

    using Xunit;

    public class CreateCustomerTests
    {
        [Fact]
        public void Given_Valid_Values_Customer_Should_Be_Created_Static_Factory()
        {
            // Arrange
            CustomerId id = new CustomerId();
            CustomerAddress address = new CustomerAddress("Country", "City", 12345, "address");

            // Act
            Customer customer = Customer.Create(id, address);

            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(id);
            customer.Version.ShouldBe(1);
            customer.Address.Equals(address).ShouldBeTrue();
            customer.Events.Count().ShouldBe(1);

            IDomainEvent @event = customer.Events.Single();
            @event.ShouldBeOfType<CustomerCreated>();
            ((CustomerCreated)@event).Customer.ShouldNotBeNull();
            ((CustomerCreated)@event).Customer.Equals(customer).ShouldBeTrue();
        }

        [Fact]
        public void Given_Valid_Values_Customer_Should_Be_Created_Contructor_One()
        {
            // Arrange
            CustomerId id = new CustomerId();
            CustomerAddress address = new CustomerAddress("Country", "City", 12345, "address");

            // Act
            Customer customer = new Customer(id, address);

            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(id);
            customer.Version.ShouldBe(0);
            customer.Address.Equals(address).ShouldBeTrue();
        }

        [Fact]
        public void Given_Valid_Values_Customer_Should_Be_Created_Contructor_Two()
        {
            // Arrange
            CustomerId id = new CustomerId();
            CustomerAddress address = new CustomerAddress("Country", "City", 12345, "address");

            // Act
            Customer customer = new Customer(id, address, 100);

            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(id);
            customer.Version.ShouldBe(100);
            customer.Address.Equals(address).ShouldBeTrue();
        }

        [Fact]
        public void Given_Empty_Customer_Should_Throw_An_Exception()
        {
            // Arrange
            CustomerAddress address = new CustomerAddress("Country", "City", 12345, "address");

            // Act
            Exception exception = Record.Exception(() => Customer.Create(Guid.Empty, address));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerIdException>();
        }

        [Fact]
        public void Given_Null_Customer_Address_List_Should_Throw_An_Exception()
        {
            // Arrange
            CustomerId id = new CustomerId();

            // Act
            Exception exception = Record.Exception(() => Customer.Create(id, null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerAddressException>();
        }
    }
}

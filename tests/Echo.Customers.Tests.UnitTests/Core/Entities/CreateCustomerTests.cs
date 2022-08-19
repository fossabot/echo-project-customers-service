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
        // Arrange
        private static readonly CustomerId id = new CustomerId();
        private static readonly CustomerDetails details = new CustomerDetails("Name", "Tenant");
        private static readonly CustomerAddress address = new CustomerAddress("Country", "City", 12345, "address");

        [Fact]
        public void Given_Valid_Values_Customer_Should_Be_Created_Static_Factory()
        {
            // Act
            Customer customer = Customer.Create(id, details, address);

            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(id);
            customer.Version.ShouldBe(1);
            customer.Details.Equals(details).ShouldBeTrue();
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
            // Act
            Customer customer = new Customer(id, details, address);

            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(id);
            customer.Version.ShouldBe(0);
            customer.Address.Equals(address).ShouldBeTrue();
        }

        [Fact]
        public void Given_Valid_Values_Customer_Should_Be_Created_Contructor_Two()
        {
            Customer customer = new Customer(id, details, address, 100);

            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(id);
            customer.Version.ShouldBe(100);
            customer.Address.Equals(address).ShouldBeTrue();
        }

        [Fact]
        public void Given_Empty_Customer_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => Customer.Create(Guid.Empty, details, address));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerIdException>();
        }

        [Fact]
        public void Given_Null_Customer_Details_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => Customer.Create(id, null, address));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerDetailsException>();
        }

        [Fact]
        public void Given_Null_Customer_Address_List_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => Customer.Create(id, details, null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerAddressException>();
        }
    }
}

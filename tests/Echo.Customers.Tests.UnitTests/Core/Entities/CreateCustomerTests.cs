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
            List<CustomerAddress> addresses = new List<CustomerAddress>
                {
                    address
                };

            // Act
            Customer customer = Customer.Create(id, addresses);

            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(id);
            customer.Version.ShouldBe(1);
            customer.CustomerAddresses.Count().ShouldBe(1);
            customer.CustomerAddresses.First().Equals(address).ShouldBeTrue();
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
            List<CustomerAddress> addresses = new List<CustomerAddress>
                {
                    address
                };

            // Act
            Customer customer = new Customer(id, addresses);

            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(id);
            customer.Version.ShouldBe(0);
            customer.CustomerAddresses.Count().ShouldBe(1);
            customer.CustomerAddresses.First().Equals(address).ShouldBeTrue();
        }

        [Fact]
        public void Given_Valid_Values_Customer_Should_Be_Created_Contructor_Two()
        {
            // Arrange
            CustomerId id = new CustomerId();
            CustomerAddress address = new CustomerAddress("Country", "City", 12345, "address");
            List<CustomerAddress> addresses = new List<CustomerAddress>
                {
                    address
                };

            // Act
            Customer customer = new Customer(id, addresses, 100);

            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(id);
            customer.Version.ShouldBe(100);
            customer.CustomerAddresses.Count().ShouldBe(1);
            customer.CustomerAddresses.First().Equals(address).ShouldBeTrue();
        }

        [Fact]
        public void Given_Empty_Customer_Should_Throw_An_Exception()
        {
            // Arrange
            CustomerAddress address = new CustomerAddress("Country", "City", 12345, "address");
            List<CustomerAddress> addresses = new List<CustomerAddress>
                {
                    address
                };

            // Act
            Exception exception = Record.Exception(() => Customer.Create(Guid.Empty, addresses));

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

        [Fact]
        public void Given_Null_Customer_Address_In_List_Should_Throw_An_Exception()
        {
            // Arrange
            CustomerId id = new CustomerId();

            // Act
            Exception exception = Record.Exception(() => Customer.Create(id, new List<CustomerAddress> { null }));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAddressException>();
        }

        [Fact]
        public void Given_More_Then_One_Primary_Customer_Address_In_List_Should_Throw_An_Exception()
        {
            // Arrange
            CustomerId id = new CustomerId();
           
            List<CustomerAddress> addresses = new List<CustomerAddress>
                {
                    new CustomerAddress("Country1", "City1", 1, "address1", true),
                    new CustomerAddress("Country2", "City2", 2, "address2", true)
                };

            // Act
            Exception exception = Record.Exception(() => Customer.Create(id, addresses));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<TooManyPrimaryCustomerAddressException>();
        }
    }
}

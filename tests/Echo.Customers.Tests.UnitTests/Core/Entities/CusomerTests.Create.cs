namespace Echo.Customers.Tests.UnitTests.Core.Entities
{
    using Echo.Customers.Core.Contracts;
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.Events;
    using Echo.Customers.Core.Exceptions;

    using Shouldly;

    using System.Linq;

    using Xunit;

    public partial class CustomerTests
    {

        [Fact]
        public void Given_Valid_Values_Create_Should_Return_Customer()
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
        public void Given_Empty_ID_Create_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => Customer.Create(Guid.Empty, details, address));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerIdException>();
            ((InvalidCustomerIdException)exception).Id.ShouldBe(Guid.Empty);
        }

        [Fact]
        public void Given_Null_Customer_Details_Create_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => Customer.Create(id, null, address));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerDetailsException>();
        }

        [Fact]
        public void Given_Null_Customer_Address_Create_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => Customer.Create(id, details, null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerAddressException>();
        }
    }
}

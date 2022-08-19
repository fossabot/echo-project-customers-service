namespace Echo.Customers.Tests.UnitTests.Core.Entities
{
    using Echo.Customers.Core.Contracts;
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.Enums;
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
            //Arrange 
            string name = "Name";

            // Act
            Customer customer = Customer.Create(id, name);

            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(id);
            customer.Version.ShouldBe(1);
            customer.State.ShouldBe(CustomerState.Incomplete);
            customer.Details.ShouldNotBeNull();
            customer.Details.Name.ShouldBe(name);
            customer.Address.ShouldNotBeNull();
            customer.Events.Count().ShouldBe(1);

            IDomainEvent @event = customer.Events.Single();
            @event.ShouldBeOfType<CustomerCreated>();
            ((CustomerCreated)@event).Customer.ShouldNotBeNull();
            ((CustomerCreated)@event).Customer.Equals(customer).ShouldBeTrue();
        }


        [Fact]
        public void Given_Empty_ID_Create_Should_Throw_An_Exception()
        {
            //Arrange 
            string name = "Name";

            // Act
            Exception exception = Record.Exception(() => Customer.Create(Guid.Empty, name));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerIdException>();
            ((InvalidCustomerIdException)exception).Id.ShouldBe(Guid.Empty);
        }

        [Fact]
        public void Given_Null_Customer_Details_Create_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => Customer.Create(id, null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerDetailsException>();
        }
    }
}

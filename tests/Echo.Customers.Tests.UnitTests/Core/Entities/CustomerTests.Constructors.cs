namespace Echo.Customers.Tests.UnitTests.Core.Entities
{
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.Enums;
    using Echo.Customers.Core.Exceptions;

    using Shouldly;

    using Xunit;

    public partial class CustomerTests
    {
        [Fact]
        public void Given_Valid_Values_Customer_Should_Be_Created_Constructor_One()
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
        public void Given_Valid_Values_Customer_Should_Be_Created_Constructor_Two()
        {
            Customer customer = new Customer(id, details, address, 100, CustomerState.Unknown, createOn, lastUpdate);

            // Assert
            customer.ShouldNotBeNull();
            customer.Id.ShouldBe(id);
            customer.Version.ShouldBe(100);
            customer.Address.Equals(address).ShouldBeTrue();
        }

        [Fact]
        public void Given_Null_Customer_Details_Constructor_One_Should_Throw_Exception()
        {
            // Act
            // Act
            Exception exception = Record.Exception(() => new Customer(id, null, address));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerDetailsException>();
        }

        [Fact]
        public void Given_Null_Customer_Details_Constructor_Two_Should_Throw_Exception()
        {
            // Act
            // Act
            Exception exception = Record.Exception(() => new Customer(id, null, address, 0, CustomerState.Unknown, createOn, lastUpdate));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerDetailsException>();
        }

        [Fact]
        public void Given_Null_Customer_Address_Constructor_One_Should_Throw_Exception()
        {
            // Act
            // Act
            Exception exception = Record.Exception(() => new Customer(id, details, null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerAddressException>();
        }

        [Fact]
        public void Given_Null_Customer_Address_Constructor_Two_Should_Throw_Exception()
        {
            // Act
            // Act
            Exception exception = Record.Exception(() => new Customer(id, details, null, 0, CustomerState.Unknown, createOn, lastUpdate));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerAddressException>();
        }
    }
}

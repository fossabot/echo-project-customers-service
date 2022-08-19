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
            Customer customer = new Customer(id, "name");

            // Assert
            customer.ShouldNotBeNull();
        }

        [Fact]
        public void Given_Valid_Values_Customer_Should_Be_Created_Constructor_Two()
        {
            // Act
            Customer customer = new Customer(id, details, account, address, 100, CustomerState.Incomplete, createOn, lastUpdate);

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
            Exception exception = Record.Exception(() => new Customer(id, null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerDetailsException>();
        }

        [Fact]
        public void Given_Empty_Id_Constructor_Two_Should_Throw_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => new Customer(Guid.Empty, details, account, address, 0, CustomerState.Incomplete, createOn, lastUpdate));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerIdException>();
        }

        [Fact]
        public void Given_Null_Customer_Details_Constructor_Two_Should_Throw_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => new Customer(id, null, account, address, 0, CustomerState.Incomplete, createOn, lastUpdate));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerDetailsException>();
        }

        [Fact]
        public void Given_Null_Customer_Account_Constructor_Two_Should_Throw_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => new Customer(id, details, null, address, 0, CustomerState.Incomplete, createOn, lastUpdate));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerAccountException>();
        }

        [Fact]
        public void Given_Null_Customer_Address_Constructor_Two_Should_Throw_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => new Customer(id, details, account, null, 0, CustomerState.Incomplete, createOn, lastUpdate));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerAddressException>();
        }

        [Fact]
        public void Given_Negative_Customer_Version_Constructor_Two_Should_Throw_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => new Customer(id, details, account, address, -1, CustomerState.Incomplete, createOn, lastUpdate));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerException>();
            ((InvalidCustomerException)exception).Name.ShouldBe("Version");
        }
    }
}

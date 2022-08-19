namespace Echo.Customers.Tests.UnitTests.Core.Entities
{
    using Castle.Core.Resource;

    using Echo.Customers.Core.Contracts;
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.Enums;
    using Echo.Customers.Core.Events;
    using Echo.Customers.Core.Exceptions;
    using Echo.Customers.Core.ValueObjects;

    using Shouldly;

    using System.Linq;

    using Xunit;

    public partial class CustomerTests
    {

        [Fact]
        public void Given_Valid_Customer_Details_Update_Should_Trigger_Event()
        {
            //Act
            customer.ClearEvents();
            customer.UpdateCustomerDetails(details);

            //Assert
            customer.Events.Count(x => x.GetType() == typeof(CustomerDetailsChanged)).ShouldBe(1);
        }

        [Fact]
        public void Given_Null_Customer_Details_Update_Should_Trhow_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => customer.UpdateCustomerDetails(null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerDetailsException>();
        }

        [Fact]
        public void Given_Not_Valid_Customer_Details_Update_Should_Trhow_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => customer.UpdateCustomerDetails(new CustomerDetails("")));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerDetailsException>();
        }

        [Fact]
        public void Given_Valid_Customer_Account_Update_Should_Trigger_Event()
        {
            //Act
            customer.ClearEvents();
            customer.UpdateCustomerAccount(account);

            //Assert
            customer.Events.Count(x => x.GetType() == typeof(CustomerAccountChanged)).ShouldBe(1);
        }

        [Fact]
        public void Given_Null_Customer_Account_Update_Should_Trhow_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => customer.UpdateCustomerAccount(null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerAccountException>();
        }

        [Fact]
        public void Given_Not_Valid_Customer_Account_Update_Should_Trhow_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => customer.UpdateCustomerAccount(new CustomerAccount()));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAccountException>();
        }


        [Fact]
        public void Given_Valid_Customer_Address_Update_Should_Trigger_Event()
        {
            //Act
            customer.ClearEvents();
            customer.UpdateCustomerAddress(address);

            //Assert
            customer.Events.Count(x => x.GetType() == typeof(CustomerAddressChanged)).ShouldBe(1);
        }

        [Fact]
        public void Given_Null_Customer_Address_Update_Should_Trhow_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => customer.UpdateCustomerAddress(null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingCustomerAddressException>();
        }

        [Fact]
        public void Given_Not_Valid_Customer_Address_Update_Should_Trhow_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => customer.UpdateCustomerAddress(new CustomerAddress()));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAddressException>();
        }
    }
}

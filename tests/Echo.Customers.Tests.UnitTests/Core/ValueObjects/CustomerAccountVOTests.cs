namespace Echo.Customers.Tests.UnitTests.Core.ValueObjects
{
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.Enums;
    using Echo.Customers.Core.Exceptions;
    using Echo.Customers.Core.ValueObjects;

    using Shouldly;

    using System.Diagnostics.Metrics;
    using System.Net;
    using System.Security.Principal;

    using Xunit;

    public class CustomerAccountVOTests
    {
        // Arrange
        private static readonly Guid id = Guid.NewGuid();
        private static readonly string firstName = "FirstName";
        private static readonly string lastName = "LastName";
        private static readonly string email = "Email";


        [Fact]
        public void Given_Valid_Values_Customer_Account_Constructor_One_Should_Be_Created()
        {
            // Act
            CustomerAccount customerAccount = new CustomerAccount();

            // Assert
            customerAccount.ShouldNotBeNull();
            customerAccount.Id.ShouldNotBe(Guid.Empty);
        }

        [Fact]
        public void Given_Valid_Values_Customer_Account_Constructor_Two_Should_Be_Created()
        {
            // Act
            CustomerAccount customerAccount = new CustomerAccount(id, firstName, lastName, email);

            // Assert
            customerAccount.ShouldNotBeNull();
            customerAccount.Id.ShouldBe(id);
        }

        [Fact]
        public void Given_Empty_Values_Customer_Account_Constructor_Two_Should_Throw_An_Error()
        {
            // Act
            Exception exception = Record.Exception(() => new CustomerAccount(Guid.Empty, firstName, lastName, email));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAccountException>();
        }

        [Fact]
        public void Given_Null_First_Name_Values_Customer_Account_Constructor_Two_Should_Throw_An_Error()
        {
            // Act
            Exception exception = Record.Exception(() => new CustomerAccount(Guid.Empty, null, lastName, email));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAccountException>();
        }

        [Fact]
        public void Given_Null_Last_Name_Values_Customer_Account_Constructor_Two_Should_Throw_An_Error()
        {
            // Act
            Exception exception = Record.Exception(() => new CustomerAccount(Guid.Empty, firstName, null, email));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAccountException>();
        }

        [Fact]
        public void Given_Null_Email_Values_Customer_Account_Constructor_Two_Should_Throw_An_Error()
        {
            // Act
            Exception exception = Record.Exception(() => new CustomerAccount(Guid.Empty, firstName, lastName, null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAccountException>();
        }
    }
}

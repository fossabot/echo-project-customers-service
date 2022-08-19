namespace Echo.Customers.Tests.UnitTests.Core.ValueObjects
{
    using Echo.Customers.Core.Exceptions;
    using Echo.Customers.Core.ValueObjects;

    using Shouldly;

    using System.Diagnostics.Metrics;
    using System.Net;

    using Xunit;

    public class CustomerDetailsVOTests
    {
        // Arrange
        private static readonly string name = "Name";
        private static readonly string tenant = "Tenant";


        [Fact]
        public void Given_Valid_Values_Customer_Details_Should_Be_Created()
        {
            // Act
            CustomerDetails customerDetails = new CustomerDetails(name);

            // Assert
            customerDetails.ShouldNotBeNull();
            customerDetails.Name.ShouldBe(name);
        }

        [Fact]
        public void Given_Null_Name_Customer_Details_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => new CustomerDetails(null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerDetailsException>();
            ((InvalidCustomerDetailsException)exception).Name.ShouldBe("Name");
        }

        [Fact]
        public void Given_Identicle_Customer_Details_Equal_Should_Return_True()
        {
            // Act
            CustomerDetails customerDetails = new CustomerDetails(name);

            // Assert
            customerDetails.Equals(customerDetails).ShouldBeTrue();
        }

        [Fact]
        public void Given_DIfferent_Customer_Details_Equal_Should_Return_False()
        {
            // Act
            CustomerDetails customerDetails1 = new CustomerDetails(name);
            CustomerDetails CustomerDetails2 = new CustomerDetails(name + " 1");

            // Assert
            customerDetails1.Equals(CustomerDetails2).ShouldBeFalse();
        }

        [Fact]
        public void Given_Null_Customer_Details_Equal_Should_Return_False()
        {
            // Act
            CustomerDetails customerDetails = new CustomerDetails(name);

            // Assert
            customerDetails.Equals((CustomerDetails)null).ShouldBeFalse();
        }

        [Fact]
        public void Given_Empty_Object_Customer_Details_Equal_Should_Return_False()
        {
            // Act
            CustomerDetails customerDetails = new CustomerDetails(name);

            // Assert
            customerDetails.Equals(new { }).ShouldBeFalse();
        }

        [Fact]
        public void Given_Object_Customer_Details_Equal_Should_Return_True()
        {
            // Act
            CustomerDetails customerDetails = new CustomerDetails(name);

            // Assert
            customerDetails.Equals((object)customerDetails).ShouldBeTrue();
        }

        [Fact]
        public void Given_Null_Object_Customer_Address_Equal_Should_Return_False()
        {
            // Act
            CustomerDetails customerDetails = new CustomerDetails(name);

            // Assert
            customerDetails.Equals((object)null).ShouldBeFalse();
        }

        [Fact]
        public void Hash_Customer_Address_Should_Be_Created()
        {
            //Act
            CustomerDetails customerDetails = new CustomerDetails(name);

            //Assert
            customerDetails.GetHashCode().ShouldNotBe(0);
        }
    }
}

namespace Echo.Customers.Tests.UnitTests.Core.ValueObjects
{
    using System.Diagnostics.Metrics;
    using System.Linq;
    using System.Net;

    using Echo.Customers.Core.Contracts;
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.Events;
    using Echo.Customers.Core.Exceptions;
    using Echo.Customers.Core.ValueObjects;

    using Shouldly;

    using Xunit;

    public class CreateCustomerAddressTests
    {
        // Arrange
        private readonly string country = "Country";
        private readonly string city = "City";
        private readonly int postCode = 12345678;
        private readonly string address = "Address";

        [Fact]
        public void Given_Valid_Values_Customer_Info_Should_Be_Created()
        {
            // Act
            CustomerAddress customerInfo = new CustomerAddress(country, city, postCode, address);
            
            // Assert
            customerInfo.ShouldNotBeNull();
        }

        [Fact]
        public void Given_Null_Country_Customer_Info_Should_Throw_An_Exception()
        {

            // Act
            Exception exception = Record.Exception(() => new CustomerAddress(null, city, postCode, address));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAddressException>();
        }

        [Fact]
        public void Given_Null_City_Customer_Info_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => new CustomerAddress(country, null, postCode, address));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAddressException>();
        }

        [Fact]
        public void Given_Negative_PostCode_Customer_Info_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => new CustomerAddress(country, city, -1, address));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAddressException>();
        }

        [Fact]
        public void Given_Null_Address_Customer_Info_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => new CustomerAddress(country, city, postCode, null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAddressException>();
        }

        [Fact]
        public void Given_Identicle_Customer_Address_Equal_Should_Return_True()
        {
            // Act
            CustomerAddress customerInfo1 = new CustomerAddress(country, city, postCode, address);
            CustomerAddress customerInfo2 = new CustomerAddress(country, city, postCode, address);

            // Assert
            customerInfo1.Equals(customerInfo2).ShouldBeTrue();
        }

        [Fact]
        public void Given_DIfferent_Customer_Address_Equal_Should_Return_False()
        {
            // Act
            CustomerAddress customerInfo1 = new CustomerAddress(country + " 1", city, postCode, address);
            CustomerAddress customerInfo2 = new CustomerAddress(country, city + " 2", postCode, address);

            // Assert
            customerInfo1.Equals(customerInfo2).ShouldBeFalse();
        }

        [Fact]
        public void Given_Null_Customer_Address_Equal_Should_Return_False()
        {
            // Act
            CustomerAddress customerInfo = new CustomerAddress(country, city, postCode, address);

            // Assert
            customerInfo.Equals(null).ShouldBeFalse();
        }

        [Fact]
        public void To_String_Should_Return_Expected_String()
        {
            // Act
            CustomerAddress customerInfo = new CustomerAddress(country, city, postCode, address);
            string customerInfoAsString = customerInfo.ToString();

            // Assert
            customerInfoAsString.ShouldNotBeNullOrEmpty();
            customerInfoAsString.ShouldNotBeSameAs($"{address}, {country}, {postCode} {city}");
        }
    }
}

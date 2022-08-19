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

    public class CustomerAddressVOTests
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
            CustomerAddress customerAddress = new CustomerAddress(country, city, postCode, address);

            // Assert
            customerAddress.ShouldNotBeNull();
            customerAddress.Country.ShouldBe(country);
            customerAddress.City.ShouldBe(city);
            customerAddress.PostCode.ShouldBe(postCode);
            customerAddress.Address.ShouldBe(address);
        }

        [Fact]
        public void Given_Null_Country_Customer_Info_Should_Throw_An_Exception()
        {

            // Act
            Exception exception = Record.Exception(() => new CustomerAddress(null, city, postCode, address));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAddressException>();
            ((InvalidCustomerAddressException)exception).Name.ShouldBe("Country");
            ((InvalidCustomerAddressException)exception).Code.ShouldBe("invalid_customer_address");
        }

        [Fact]
        public void Given_Null_City_Customer_Info_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => new CustomerAddress(country, null, postCode, address));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAddressException>();
            ((InvalidCustomerAddressException)exception).Name.ShouldBe("City");
            ((InvalidCustomerAddressException)exception).Code.ShouldBe("invalid_customer_address");
        }

        [Fact]
        public void Given_Negative_PostCode_Customer_Info_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => new CustomerAddress(country, city, -1, address));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAddressException>();
            ((InvalidCustomerAddressException)exception).Name.ShouldBe("PostCode");
            ((InvalidCustomerAddressException)exception).Code.ShouldBe("invalid_customer_address");
        }

        [Fact]
        public void Given_Null_Address_Customer_Info_Should_Throw_An_Exception()
        {
            // Act
            Exception exception = Record.Exception(() => new CustomerAddress(country, city, postCode, null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAddressException>();
            ((InvalidCustomerAddressException)exception).Name.ShouldBe("Address");
            ((InvalidCustomerAddressException)exception).Code.ShouldBe("invalid_customer_address");
        }

        [Fact]
        public void Given_Identicle_Customer_Address_Equal_Should_Return_True()
        {
            // Act
            CustomerAddress customerAddress1 = new CustomerAddress(country, city, postCode, address);
            CustomerAddress customerAddress2 = new CustomerAddress(country, city, postCode, address);

            // Assert
            customerAddress1.Equals(customerAddress2).ShouldBeTrue();
        }

        [Fact]
        public void Given_DIfferent_Customer_Address_Equal_Should_Return_False()
        {
            // Act
            CustomerAddress customerAddress1 = new CustomerAddress(country + " 1", city, postCode, address);
            CustomerAddress customerAddress2 = new CustomerAddress(country, city + " 2", postCode, address);

            // Assert
            customerAddress1.Equals(customerAddress2).ShouldBeFalse();
        }

        [Fact]
        public void Given_Null_Customer_Address_Equal_Should_Return_False()
        {
            // Act
            CustomerAddress customerAddress = new CustomerAddress(country, city, postCode, address);

            // Assert
            customerAddress.Equals((CustomerAddress)null).ShouldBeFalse();
        }

        [Fact]
        public void Given_Empty_Object_Customer_Address_Equal_Should_Return_False()
        {
            // Act
            CustomerAddress customerAddress = new CustomerAddress(country, city, postCode, address);

            // Assert
            customerAddress.Equals(new { }).ShouldBeFalse();
        }

        [Fact]
        public void Given_Object_Customer_Address_Equal_Should_Return_True()
        {
            // Act
            CustomerAddress customerAddress = new CustomerAddress(country, city, postCode, address);

            // Assert
            customerAddress.Equals((object)customerAddress).ShouldBeTrue();
        }

        [Fact]
        public void Given_Null_Object_Customer_Address_Equal_Should_Return_False()
        {
            // Act
            CustomerAddress customerAddress = new CustomerAddress(country, city, postCode, address);

            // Assert
            customerAddress.Equals((object)null).ShouldBeFalse();
        }

        [Fact]
        public void To_String_Should_Return_Expected_String()
        {
            // Act
            CustomerAddress customerAddress = new CustomerAddress(country, city, postCode, address);
            string customerAddressAsString = customerAddress.ToString();

            // Assert
            customerAddressAsString.ShouldNotBeNullOrEmpty();
            customerAddressAsString.ShouldNotBeSameAs($"{address}, {country}, {postCode} {city}");
        }

        [Fact]
        public void Hash_Customer_Address_Should_Be_Created()
        {
            //Act
            CustomerAddress customerAddress = new CustomerAddress(country, city, postCode, address);

            //Assert
            customerAddress.GetHashCode().ShouldNotBe(0);
        }
    }
}

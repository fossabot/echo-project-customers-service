namespace Echo.Customers.Tests.UnitTests.Core.Entities
{
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.Exceptions;
    using Echo.Customers.Core.ValueObjects;

    using Shouldly;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xunit;
    using Xunit.Sdk;

    public class CustomersAddressTest
    {
        private readonly Customer customer = Customer.Create(
            new CustomerId(),
            new List<CustomerAddress>
            {
                new CustomerAddress("Country", "City", 12345, "address", true)
            });

        [Fact]
        public void Add_Address_Shlould_Be_Success()
        {
            //Arrange
            CustomerAddress address = new CustomerAddress("Country1", "City", 12345, "address", false);

            //Act
            customer.AddAddress(address);

            //Assert
            customer.Addresses.Count().ShouldBe(2);
        }

        [Fact]
        public void Add_Null_Address_Shlould_Be_Throw_Exception()
        {
            //Act
            Exception exception = Record.Exception(() => customer.AddAddress(null));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidCustomerAddressException>();

        }

        [Fact]
        public void Add_Primary_Address_Shlould_Be_Throw_Exception()
        {
            //Act
            Exception exception = Record.Exception(() => customer.AddAddress(
                new CustomerAddress("Country", "City", 12345, "address", true)));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<TooManyPrimaryCustomerAddressException>();

        }
    }
}

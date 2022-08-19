namespace Echo.Customers.Tests.UnitTests.Core.Entities
{
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.ValueObjects;

    using Shouldly;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xunit;

    public class CustomerTests
    {
        // Arrange
        private static readonly CustomerId id = new CustomerId();
        private static readonly CustomerDetails details = new CustomerDetails("Name", "Tenant");
        private static readonly CustomerAddress address = new CustomerAddress("Country", "City", 12345, "address");
        private static readonly Customer customer = Customer.Create(id, details, address);

        [Fact]
        public void Givven_Customer_Equals_Should_Return_True()
        {
            //Arrange
            Customer customer1 = Customer.Create(id, details, address);

            //Act
            bool isEqual = customer.Equals(customer1);

            //Assert
            isEqual.ShouldBeTrue();
        }

        [Fact]
        public void Givven_Same_Object_Equals_Should_Return_True()
        {
            //Act
            bool isEqual = customer.Equals((object)customer);

            //Assert
            isEqual.ShouldBeTrue();
        }

        [Fact]
        public void Givven_Null_Customer_Equals_Should_Return_False()
        {

            //Act
            bool isEqual = customer.Equals(null);

            //Assert
            isEqual.ShouldBeFalse();
        }

        [Fact]
        public void Givven_Empty_Object_Customer_Equals_Should_Return_False()
        {

            //Act
            bool isEqual = customer.Equals(new { });

            //Assert
            isEqual.ShouldBeFalse();
        }

        [Fact]
        public void Givven_Null_Object_Customer_Equals_Should_Return_False()
        {

            //Act
            bool isEqual = customer.Equals((object)null);

            //Assert
            isEqual.ShouldBeFalse();
        }

        [Fact]
        public void Hash_Customer_Should_Be_Created()
        {
            //Act
            int hash = customer.GetHashCode();

            //Assert
            hash.ShouldNotBe(0);
        }
    }
}

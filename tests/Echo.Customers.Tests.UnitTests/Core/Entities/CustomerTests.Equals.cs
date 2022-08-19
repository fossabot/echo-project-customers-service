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

    public partial class CustomerTests
    {
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
    }
}

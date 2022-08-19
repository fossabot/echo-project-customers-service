namespace Echo.Customers.Tests.UnitTests.Core.Entities
{
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.Enums;

    using Shouldly;

    using Xunit;

    public partial class CustomerTests
    {
        [Fact]
        public void Givven_Customer_Equals_Should_Return_True()
        {
            //Arrange
            Customer customer1 = new Customer(id, details, account, address, 0, CustomerState.Incomplete, createOn, lastUpdate);
            Customer customer2 = new Customer(id, details, account, address, 0, CustomerState.Incomplete, createOn, lastUpdate);

            //Act
            bool isEqual = customer1.Equals(customer2);

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

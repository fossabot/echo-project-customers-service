namespace Echo.Customers.Tests.UnitTests.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Metrics;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.ValueObjects;

    using Shouldly;

    using Xunit;

    public class CustomerIdTests
    {
        [Fact]
        public void Empty_Constructor_Valid_CustomerId_Should_Be_Created()
        {
            //Act
            CustomerId customerId = new CustomerId();

            //Assert
            customerId.Value.ShouldBeOfType<Guid>();
        }

        [Fact]
        public void Constructor_CustomerId_Should_Be_Created()
        {
            //Arrange 
            Guid id = Guid.NewGuid();

            //Act
            CustomerId customerId = new CustomerId(id);

            //Assert
            customerId.Value.ShouldBeOfType<Guid>();
            customerId.Value.ShouldBe(id);
        }

        [Fact]
        public void Hash_CustomerId_Should_Be_Created()
        {
            //Arrange 
            Guid id = Guid.NewGuid();

            //Act
            CustomerId customerId = new CustomerId(id);

            //Assert
            customerId.GetHashCode().ShouldBe(id.GetHashCode());
        }

        [Fact]
        public void To_String_CustomerId_Should_Be_True()
        {
            //Arrange 
            Guid id = Guid.NewGuid();

            //Act
            CustomerId customerId = new CustomerId(id);

            //Assert
            customerId.ToString().ShouldBe(id.ToString());
        }

        [Fact]
        public void Given_Value_Equal_Should_Return_True()
        {
            //Act
            CustomerId customerId = new CustomerId();

            //Assert
            customerId.Value.Equals(customerId).ShouldBeTrue();
        }

        [Fact]
        public void Given_Empty_Object_Value_Equal_Should_Return_False()
        {
            //Act
            CustomerId customerId = new CustomerId();

            //Assert
            customerId.Value.Equals(new { }).ShouldBeFalse();
        }


        [Fact]
        public void Given_Null_Value_Equal_Should_Return_False()
        {
            //Act
            CustomerId customerId = new CustomerId();

            //Assert
            customerId.Value.Equals(null).ShouldBeFalse();
        }

        [Fact]
        public void Given_Object_Value_Equal_Should_Return_False()
        {
            //Act
            CustomerId customerId = new CustomerId();

            //Assert
            customerId.Value.Equals("string").ShouldBeFalse();
        }

        [Fact]
        public void Given_Customer_Id_Equal_Should_Return_True_One()
        {
            //Act
            CustomerId customerId = new CustomerId();

            //Assert
            customerId.Equals(customerId).ShouldBeTrue();
        }

        [Fact]
        public void Given_Customer_Id_Equal_Should_Return_True_Two()
        {
            //Arrange 
            Guid id = Guid.NewGuid();

            //Act
            CustomerId customerId = new CustomerId(id);

            //Assert
            customerId.Equals(id).ShouldBeTrue();
        }

        [Fact]
        public void Null_Customer_Id_Equal_Should_Return_False()
        {
            //Act
            CustomerId customerId = new CustomerId();

            //Assert
            customerId.Equals(null).ShouldBeFalse();
        }

        [Fact]
        public void Empty_Object_Customer_Id_Equal_Should_Return_False()
        {
            //Act
            CustomerId customerId = new CustomerId();

            //Assert
            customerId.Equals(new { }).ShouldBeFalse();
        }
    }
}

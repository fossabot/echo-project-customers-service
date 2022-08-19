namespace Echo.Customers.Tests.UnitTests.Core.Entities
{
    using Echo.Customers.Core.Entities;
    using Echo.Customers.Core.Enums;
    using Echo.Customers.Core.ValueObjects;

    using Shouldly;

    using Xunit;

    public partial class CustomerTests
    {
        // Arrange
        private static readonly string name = "Name";
        private static readonly string tenant = "Tenant";
        private static readonly Guid billingAccount = Guid.NewGuid();
        private static readonly Guid customerId = Guid.NewGuid();
        private static readonly string firstName = "FirstName";
        private static readonly string lastName = "LastName";
        private static readonly string email = "Email";
        private static readonly CustomerId id = new CustomerId();
        private static readonly CustomerDetails details = new CustomerDetails(name, tenant, billingAccount);
        private static readonly CustomerAccount account = new CustomerAccount(id, firstName, lastName, email);
        private static readonly CustomerAddress address = new CustomerAddress("Country", "City", 12345, "address");
        private static readonly DateTime createOn = DateTime.UtcNow;
        private static readonly DateTime lastUpdate = DateTime.UtcNow;
        private static readonly Customer customer = Customer.Create(id, name);

        [Fact]
        public void Hash_Customer_Should_Be_Created()
        {
            //Act
            int hash = customer.GetHashCode();

            //Assert
            hash.ShouldNotBe(0);
        }

        [Fact]
        public void SetIncomplete_Should_Be_Change_State()
        {
            //Act
            customer.SetIncomplete();

            //Assert
            customer.State.ShouldBe(CustomerState.Incomplete);
        }

        [Fact]
        public void Activate_Should_Be_Change_State()
        {
            //Act
            customer.Activate();

            //Assert
            customer.State.ShouldBe(CustomerState.Active);
        }

        [Fact]
        public void Suspend_Should_Be_Change_State()
        {
            //Act
            customer.Suspend();

            //Assert
            customer.State.ShouldBe(CustomerState.Suspended);
        }

        [Fact]
        public void Lock_Should_Be_Change_State()
        {
            //Act
            customer.Lock();

            //Assert
            customer.State.ShouldBe(CustomerState.Locked);
        }

        [Fact]
        public void SoftDelete_Should_Be_Change_State()
        {
            //Act
            customer.SoftDelete();

            //Assert
            customer.State.ShouldBe(CustomerState.Deleted);
        }
    }
}

namespace Echo.Customers.Core.Repositories
{
    using System.Threading.Tasks;
    using Echo.Customers.Core.Entities;

    internal interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();

        Task<Customer> GetCustomerAsync(CustomerId id);

        Task<bool> CustomerExistsAsync(CustomerId id);

        Task AddCustomerAsync(Customer resource);

        Task UpdateCustomerAsync(Customer resource);

        Task DeleteCustomerAsync(Customer id);
    }
}

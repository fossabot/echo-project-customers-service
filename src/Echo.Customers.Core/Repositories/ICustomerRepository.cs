namespace Echo.Customers.Core.Repositories
{
    using System.Threading.Tasks;

    using Echo.Customers.Core.Entities;

    /// <summary>
    /// Customer Repository interface 
    /// </summary>
    internal interface ICustomerRepository
    {
        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customer>> GetAllAsync();

        /// <summary>
        /// Gets the customer asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Customer> GetCustomerAsync(CustomerId id);

        /// <summary>
        /// Customers the exists asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> CustomerExistsAsync(CustomerId id);

        /// <summary>
        /// Adds the customer asynchronous.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns></returns>
        Task AddCustomerAsync(Customer resource);

        /// <summary>
        /// Updates the customer asynchronous.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns></returns>
        Task UpdateCustomerAsync(Customer resource);

        /// <summary>
        /// Deletes the customer asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteCustomerAsync(Customer id);
    }
}

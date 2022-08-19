namespace Echo.Customers.Core.ValueObjects
{
    using Echo.Customers.Core.Exceptions;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Customer Account Value Object
    /// </summary>
    /// <seealso cref="Echo.Customers.Core.ValueObjects.ValueObject" />
    public class CustomerAccount : ValueObject
    {
        /// <summary>
        /// Gets the Account identifier.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the Account first name.
        /// </summary>
        public string FirstName { get; init; }

        /// <summary>
        /// Gets the last Account name.
        /// </summary>
        public string LastName { get; init; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Gets the Account email.
        /// </summary>
        public string Email { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAccount"/> class.
        /// </summary>
        public CustomerAccount()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAccount"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <exception cref="Echo.Customers.Core.Exceptions.InvalidCustomerAccountException"></exception>
        public CustomerAccount(Guid id, string firstName, string lastName, string email)
        {
            this.Id = id.Equals(Guid.Empty) ? throw new InvalidCustomerAccountException(nameof(this.Id)) : id;
            this.FirstName = firstName ?? throw new InvalidCustomerAccountException(nameof(this.FirstName));
            this.LastName = lastName ?? throw new InvalidCustomerAccountException(nameof(this.LastName));
            this.Email = email ?? throw new InvalidCustomerAccountException(nameof(this.Email));
        }

        /// <summary>
        /// Returns true if CustomerAccount is valid.
        /// </summary>
        /// <returns></returns>
        public override bool IsValid()
        {
            bool isValid = true;
            isValid = isValid && !string.IsNullOrEmpty(this.FirstName);
            isValid = isValid && !string.IsNullOrWhiteSpace(this.FirstName);
            isValid = isValid && !string.IsNullOrEmpty(this.LastName);
            isValid = isValid && !string.IsNullOrWhiteSpace(this.LastName);
            isValid = isValid && !string.IsNullOrEmpty(this.Email);
            isValid = isValid && !string.IsNullOrWhiteSpace(this.Email);

            return isValid;
        }

        /// <summary>
        /// Gets the equality components.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return FirstName;
            yield return LastName;
            yield return Email;
        }
    }
}

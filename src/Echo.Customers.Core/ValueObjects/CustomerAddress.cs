﻿namespace Echo.Customers.Core.ValueObjects
{
    using System.Collections.Generic;

    using Echo.Customers.Core.Exceptions;

    /// <summary>
    /// Customer Address Value Object
    /// </summary>
    /// <seealso cref="ValueObject" />
    public class CustomerAddress : ValueObject
    {
        /// <summary>
        /// Gets the Customer's country.
        /// </summary>
        public string Country { get; init; }

        /// <summary>
        /// Gets the Customer's city.
        /// </summary>
        public string City { get; init; }

        /// <summary>
        /// Gets the Customer's post code.
        /// </summary>
        public int PostCode { get; init; }

        /// <summary>
        /// Gets the Customer's street.
        /// </summary>
        public string Address { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAddress"/> class.
        /// </summary>
        public CustomerAddress() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAddress"/> class.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="city">The city.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="address">The address.</param>
        /// <exception cref="InvalidCustomerAddressException"></exception>
        public CustomerAddress(string country, string city, int postCode, string address)
        {
            Country = country ?? throw new InvalidCustomerAddressException(nameof(Country));
            City = city ?? throw new InvalidCustomerAddressException(nameof(City));
            PostCode = postCode <= 0 ? throw new InvalidCustomerAddressException(nameof(PostCode)) : postCode;
            Address = address ?? throw new InvalidCustomerAddressException(nameof(Address));
        }

        /// <summary>
        /// Returns true if Customer Details is valid.
        /// </summary>
        public override bool IsValid()
        {
            bool isValid = true;
            isValid = isValid && !string.IsNullOrEmpty(this.Country);
            isValid = isValid && !string.IsNullOrWhiteSpace(this.Country);
            isValid = isValid && !string.IsNullOrEmpty(this.City);
            isValid = isValid && !string.IsNullOrWhiteSpace(this.City);
            isValid = isValid && this.PostCode > 0;
            isValid = isValid && !string.IsNullOrEmpty(this.Address);
            isValid = isValid && !string.IsNullOrWhiteSpace(this.Address);

            return isValid;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{Address}, {Country}, {PostCode} {City}";
        }

        /// <summary>
        /// Gets the equality components.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Country;
            yield return City;
            yield return PostCode;
            yield return Address;
        }
    }
}

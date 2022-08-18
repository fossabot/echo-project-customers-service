﻿namespace Echo.Customers.Core.Exceptions
{
    using System;

    public abstract class DomainException : Exception
    {
        public virtual string Code { get; }

        protected DomainException(string message) : base(message)
        {
            if (string.IsNullOrEmpty(this.Code))
            {
                this.Code = "core_exception";
            }
        }
    }
}
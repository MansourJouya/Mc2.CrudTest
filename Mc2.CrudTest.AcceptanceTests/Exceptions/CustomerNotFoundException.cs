﻿using System;

namespace Mc2.CrudTest.AcceptanceTests.Exceptions
{
    /// <summary>
    /// Exception thrown when a customer is not found in the repository.
    /// </summary>
    public class CustomerNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerNotFoundException"/> class.
        /// </summary>
        public CustomerNotFoundException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerNotFoundException"/> class
        /// with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CustomerNotFoundException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerNotFoundException"/> class
        /// with a specified error message and a reference to the inner exception
        /// that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        public CustomerNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}

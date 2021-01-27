using System.Collections.Generic;

namespace Distrib.Core.Domain.Validations
{
    /// <summary>
    /// Represents the result of a domain operation.
    /// </summary>
    public class DomainResult
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether the result was successful.
        /// </summary>
        public bool Succeeded { get; private set; }

        /// <summary>
        /// Gets the collection of errors registered.
        /// </summary>
        public ICollection<string> Errors { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainResult"/> class.
        /// </summary>
        /// <remarks>
        /// if no errors are added, the result will be considered successful.
        /// </remarks>
        public DomainResult()
        {
            Succeeded = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainResult"/> class.
        /// </summary>
        /// <remarks>
        /// if no errors are added, the result will be considered successful.
        /// </remarks>
        /// <param name="errors">Errors to transmit as a result.</param>
        public DomainResult(params string[] errors)
        {
            Succeeded = false;
            Errors = errors;
        }

        #endregion

        /// <summary>
        /// Adds an error to a result, which will automatically be considered unsuccessful.
        /// </summary>
        /// <param name="error">The error to be added.</param>
        public DomainResult AddError(string error)
        {
            Succeeded = false;
            Errors ??= new List<string>();
            Errors.Add(error);

            return this;
        }
    }
}

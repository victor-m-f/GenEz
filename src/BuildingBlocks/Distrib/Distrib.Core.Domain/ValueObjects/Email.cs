namespace Distrib.Core.Domain.ValueObjects
{
    /// <summary>
    /// Value object of email.
    /// </summary>
    public sealed class Email
    {
        #region Properties

        /// <summary>
        /// Gets the full email address. For example username@domain.extension.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Gets the username of the email.
        /// </summary>
        public string Username => Address.Split('@')[0];

        /// <summary>
        /// Gets the domain of the email.
        /// </summary>
        public string Domain => Address.Split('@')[1];

        /// <summary>
        /// Gets the domain name of the email.
        /// </summary>
        public string DomainName => Address.Split('@')[1].Split('.')[0];

        /// <summary>
        /// Gets the extension of the email.
        /// </summary>
        public string Extension => Address.Split('@')[1].Split('.')[1];

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        /// <param name="address">The full email address.</param>
        public Email(string address)
        {
            Address = address?.ToLower();
        }

        #endregion

        #region ValueObject Methods

        /// <summary>
        /// Returns a string that represents the current <see cref="Email"/>.
        /// </summary>
        /// <returns>The email address.</returns>
        public override string ToString() => Address;

        #endregion
    }
}

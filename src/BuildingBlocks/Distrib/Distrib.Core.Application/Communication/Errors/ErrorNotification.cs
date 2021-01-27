using MediatR;
using Newtonsoft.Json;
using System;
using System.Net;

namespace Distrib.Core.Application.Communication.Errors
{
    /// <summary>
    /// Generic system error notification.
    /// </summary>
    public class ErrorNotification : MessageBase, INotification
    {
        #region Properties

        [JsonProperty("id")]
        public Guid Id { get; private set; }
        [JsonProperty("httpStatus")]
        public string HttpStatus { get; private set; }
        [JsonProperty("httpStatusCode")]
        public int HttpStatusCode { get; private set; }
        [JsonProperty("key")]
        public string Key { get; private set; }
        [JsonProperty("value")]
        public string Value { get; private set; }
        [JsonProperty("isFatal")]
        public bool IsFatal { get; private set; }
        [JsonProperty("date")]
        public DateTime Date { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorNotification"/> class.
        /// Used only for deserialization purposes.
        /// </summary>
        public ErrorNotification()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorNotification"/> class.
        /// </summary>
        /// <param name="httpCode">The http code that represents this error.</param>
        /// <param name="key">Key value indicating where the error happened.</param>
        /// <param name="value">The description of the error.</param>
        public ErrorNotification(HttpStatusCode httpCode, string key, string value)
        {
            Date = DateTime.Now;
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
            HttpStatus = httpCode.ToString();
            HttpStatusCode = (int)httpCode;
            IsFatal = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorNotification"/> class.
        /// </summary>
        /// <param name="httpCode">The http code that represents this error.</param>
        /// <param name="key">Key value indicating where the error happened.</param>
        /// <param name="value">The description of the error.</param>
        /// <param name="isFatal">Indicates whether this error did not allow the process to achieve the main goal. Default is true.</param>
        public ErrorNotification(HttpStatusCode httpCode, string key, string value, bool isFatal)
            : this(httpCode, key, value)
        {
            IsFatal = isFatal;
        }

        #endregion
    }
}

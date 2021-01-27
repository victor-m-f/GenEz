using System;

namespace Distrib.Core.Domain.ValueObjects
{
    /// <summary>
    /// Value object of image.
    /// </summary>
    public class Image
    {
        #region Properties

        public Guid Id { get; set; }
        public string Folder { get; }
        public string Url { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        public Image(string folder)
        {
            if (string.IsNullOrWhiteSpace(folder))
            {
                throw new ArgumentNullException("Uma imagem precisa de uma pasta válida para ser criada");
            }

            Id = Guid.NewGuid();
            Folder = folder;
        }

        #endregion

        #region ValueObject Methods

        /// <summary>
        /// Returns a string that represents the current <see cref="Image"/>.
        /// </summary>
        /// <returns>The path of the image. Example: "folder/id".</returns>
        public override string ToString() => $"{Folder}/{Id}";

        #endregion
    }
}

using Distrib.Core.Domain;
using Distrib.Core.Domain.Configurations;
using Distrib.Helper.Extensions;

namespace GenEz.Character.Domain.Entities
{
    public class Spelling : EntityBase
    {
        public const int TextMaxSize = CoreConstSizes.PersonNameMax;

        #region Properties

        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value.Trim().ToTitleCase();
                NeutralText = _text.ToNeutral();
            }
        }
        public string NeutralText { get; set; }
        public PersonName PersonName { get; set; }

        #endregion

        #region Constructors

        public Spelling(string text)
        {
            Text = text;
        }

        // Required for entity framework
        private Spelling()
        {
        }

        #endregion
    }
}

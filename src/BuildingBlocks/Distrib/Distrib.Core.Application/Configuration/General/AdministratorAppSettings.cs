using Distrib.Core.Application.Configuration.AppSettings;

namespace Distrib.Core.Application.Configuration.General
{
    public class AdministratorAppSettings : AppSettingsBase
    {
        public const string SectionName = "AdministratorSettings";

        #region Properties

        public string AdministratorEmail { get; set; }
        public string AdministratorPassword { get; set; }
        public override bool IsValid => !string.IsNullOrWhiteSpace(AdministratorEmail) && !string.IsNullOrWhiteSpace(AdministratorPassword);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministratorAppSettings"/> class.
        /// </summary>
        public AdministratorAppSettings()
        {
        }

        #endregion
    }
}

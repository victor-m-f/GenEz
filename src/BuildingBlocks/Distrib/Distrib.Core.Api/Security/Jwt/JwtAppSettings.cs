using Distrib.Core.Application.Configuration.AppSettings;

namespace Distrib.Core.Api.Security.Jwt
{
    public class JwtAppSettings : AppSettingsBase
    {
        public const string SectionName = "JwtSettings";

        #region Properties

        public string JwksUrl { get; set; }
        public override bool IsValid => !string.IsNullOrWhiteSpace(JwksUrl);

        #endregion

        #region Constructors

        public JwtAppSettings()
        {
        }

        #endregion
    }
}

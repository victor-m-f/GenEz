using Microsoft.AspNetCore.Mvc;

namespace Distrib.Core.Api.Controllers
{
    /// <summary>
    /// Attribute that defines the default route for end-points.
    /// </summary>
    public class ApiRouteAttribute : RouteAttribute
    {
        private const string BaseRoute = "api/v{version:apiVersion}/";
        private const string CultureRoute = "{culture:culture}/";

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRouteAttribute"/> class.
        /// </summary>
        /// <param name="template">The template that will be added to the route.</param>
        /// <param name="withCulture">Defines whether the route will have a variable to specify the request culture.</param>
        public ApiRouteAttribute(string template = "[controller]", bool withCulture = false)
            : base(BaseRoute + (withCulture? CultureRoute : string.Empty) + template)
        {
        }
    }
}

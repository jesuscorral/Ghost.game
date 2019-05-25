using Microsoft.AspNetCore.Mvc;

namespace Ghost.Host.Mvc.Attributes
{
    public class GhostRouteAttribute : RouteAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GhostRouteAttribute"/> class.
        /// </summary>
        /// <param name="template">string value parameter</param>
        public GhostRouteAttribute(string template)
            : base("ghost/" + template)
        {
        }
    }
}
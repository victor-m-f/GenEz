using Destructurama.Attributed;
using Distrib.Helper.Helpers;
using Serilog.Core;
using Serilog.Events;
using System;

namespace Distrib.Core.Api.Configuration.Logging
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SensitiveDataAttribute : Attribute, IPropertyDestructuringAttribute
    {
        private const string DefaultMask = "*****";

        public SensitiveDataAttribute()
        {
        }

        public bool TryCreateLogEventProperty(string name, object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventProperty property)
        {
            property = new LogEventProperty(name, new ScalarValue(SystemHelper.IsProduction ? DefaultMask : value));

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleLog.Provider
{
    public class MyValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return true;
        }

        public ValueProviderResult GetValue(string key)
        {
            if (key.EndsWith("id"))
            {
                var value = "id";
                return new ValueProviderResult(value, value, CultureInfo.InvariantCulture);
            }

            if (key.EndsWith("Name"))
            {
                var value = "john";
                return new ValueProviderResult(value, value, CultureInfo.InvariantCulture);
            }
            else if (key.EndsWith("IPAddress"))
            {
                var value = "127.0.0.1";
                return new ValueProviderResult(value, value, CultureInfo.InvariantCulture);
            }

            return null;
        }
    }

    public class MyValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new MyValueProvider();
        }
    }
}
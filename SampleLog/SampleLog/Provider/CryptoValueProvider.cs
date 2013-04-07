using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SampleLog.Provider
{
    public class CryptoValueProvider : IValueProvider
    {
        RouteData routeData = null;        
        Dictionary<string, string> dictionary = null;

        public CryptoValueProvider(RouteData routeData)
        {
            this.routeData = routeData;
        }

        public bool ContainsPrefix(string prefix)
        {             
            if (this.dictionary == null)
            {
                this.dictionary = new Dictionary<string, string>();
            }

            if (this.routeData.Values["id"] != null)
            {
                this.dictionary.Add("id", this.routeData.Values["id"].ToString());
                return this.dictionary.ContainsKey(prefix.ToUpper());
            }          

            if (this.routeData.Values["controller"] != null)
            {
                this.dictionary.Add("controller", this.routeData.Values["controller"].ToString());
                return this.dictionary.ContainsKey(prefix.ToUpper());
            }

            if (this.routeData.Values["action"] != null)
            {
                this.dictionary.Add("action", this.routeData.Values["action"].ToString());
                return this.dictionary.ContainsKey(prefix.ToUpper());
            }
            
            return false;            
        }

        public ValueProviderResult GetValue(string key)
        {
            ValueProviderResult result=null;
            if (this.dictionary != null)
            {
                if (this.dictionary.ContainsKey(key))
                {
                    result = new ValueProviderResult(this.dictionary[key.ToUpper()],
                        this.dictionary[key.ToUpper()], CultureInfo.CurrentCulture);
                }  
            }
            return result;
        }
    }

    public class CryptoValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new CryptoValueProvider(controllerContext.RouteData);
        }
    }
}
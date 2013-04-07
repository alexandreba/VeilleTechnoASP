using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SampleLog.Provider
{
 public class CryptoValueProviderAttribute : FilterAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationContext filterContext)
    {
        filterContext.Controller.ValueProvider = new CryptoValueProvider(filterContext.RouteData);
    }
}
}
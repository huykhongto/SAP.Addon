using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SAP.Addon.App_Start;
using Security;
using System;
using System.Web.Security;
using Newtonsoft.Json;

namespace SAP.Addon
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new WebCoreAuthorizeAttribute());
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
            {

                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null)
                {
                    WebCorePrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<WebCorePrincipalSerializeModel>(authTicket.UserData);
                    WebCorePrincipal newUser = new WebCorePrincipal(authTicket.Name);

                    newUser.Id = serializeModel.UserId;
                    newUser.UserId = serializeModel.UserName;
                    newUser.FullName = serializeModel.FullName;
                    newUser.IsSysAdmin = serializeModel.IsSysAdmin;
                    newUser.roles = serializeModel.roles;
                    HttpContext.Current.User = newUser;
                }
            }

        }
    }
}
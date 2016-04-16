using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace DieuNgu
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    if (FormsAuthentication.SlidingExpiration)
                        authTicket = FormsAuthentication.RenewTicketIfOld(authTicket);

                    var roles = authTicket.UserData.Split(',');
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
                }
            }
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Response.Status.StartsWith("401"))
            {
                HttpContext.Current.Response.ClearContent();
                Response.Redirect("/Account/Login?returnUrl=" + Request.Url.AbsolutePath);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using Glass.Mapper.Sc;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace VirtualSummit
{
    public class Global : Sitecore.Web.Application
    {

        public void Application_Start()
        {
            var container = new Container();

            // Register your types, for instance:
            container.Register<ISitecoreContext, SitecoreContext>(ConstructorSelector.LeastParameters);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // This is an extension method from the integration package as well.
            container.RegisterMvcAttributeFilterProvider();

           // container.Verify();

            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }

        public void Application_End()
        {
        }

        public void Application_Error(object sender, EventArgs args)
        {
        }

        public void FormsAuthentication_OnAuthenticate(object sender, FormsAuthenticationEventArgs args)
        {
            string frameworkVersion = this.GetFrameworkVersion();
            if (!string.IsNullOrEmpty(frameworkVersion) && frameworkVersion.StartsWith("v4.", StringComparison.InvariantCultureIgnoreCase))
            {
                args.User = Sitecore.Context.User;
            }
        }

        string GetFrameworkVersion()
        {
            try
            {
                return System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion();
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Cannot get framework version", ex, this);
                return string.Empty;
            }
        }
    }
}
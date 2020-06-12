using FluentValidation.Mvc;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TeaMarket.BLL.Utilites;
using TeaMarket.UI.Utilites;

namespace TeaMarket.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            #region NinjectResolvers
            var uiRegistrations = new NinjectUIRegistrations();
            var businessLogicRegistrations = new NinjectRegistrations();
            var registrations = new INinjectModule[] { uiRegistrations, businessLogicRegistrations };
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            #endregion
            FluentValidationModelValidatorProvider.Configure();
            StripeConfiguration.ApiKey = "sk_test_51GsqLBLWVVwPXKpuXOMJqGA449qPT894HKycgP6upv25wkI74GlEpRFdMVXI1W8w2sIgVShUoDlIiXQ3VwSBlxp400cH1QcMCv";

        }
    }
}

using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EasyNetQTest
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        public static IBus BusConnection { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BusConnection = RabbitHutch.CreateBus("amqp://hbfbcxxk:dA9pZPfa0hQZk8GVT54O5O-KmpIeFTXm@hyena.rmq.cloudamqp.com/hbfbcxxk");
        }

        protected void Application_End()
        {
            BusConnection.Dispose();
        }
    }
}

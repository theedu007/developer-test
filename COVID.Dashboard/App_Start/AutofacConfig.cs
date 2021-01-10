using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using COVID.Dashboard.ApiClient.ApiConfig;
using COVID.Dashboard.ApiClient.Interface;
using COVID.Dashboard.Buisness.Implementation;
using COVID.Dashboard.Buisness.Interface;

namespace COVID.Dashboard.App_Start
{
    public class AutofacConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ApiClient.Implementation.ApiClient>()
                .As<IApiClient>()
                .WithParameter(new TypedParameter(typeof(ApiConfigSection), ApiConfig.GetApiConfigSection()))
                .InstancePerDependency();
            builder.RegisterType<ReportService>()
                .As<IReportService>()
                .InstancePerDependency();

                var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
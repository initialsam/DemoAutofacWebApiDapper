using Autofac.Integration.WebApi;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Demo.Common;

namespace Demo.WebApi
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var configuration = GlobalConfiguration.Configuration;

            // 註冊您的Web API控制器。
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<AppSetting>().As<IAppSetting>().InstancePerRequest();
            //builder.RegisterType<FetPaySerives>().As<IFetPaySerives>().InstancePerRequest();
            //builder.RegisterType<FetPayRepository>().As<IFetPayRepository>().InstancePerRequest();

            // 將依賴關係解析器(DependencyResolver)設置為Autofac。
            var container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
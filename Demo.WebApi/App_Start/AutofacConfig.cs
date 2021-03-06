using Autofac.Integration.WebApi;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Demo.Common;
using Demo.Service;
using Demo.Repository;
using Autofac.Core;
using Demo.WebApi.Controllers;
using System.Web.Mvc;
using Autofac.Integration.Mvc;

namespace Demo.WebApi
{
    public class AutofacConfig
    {
        public static void RegisterWebApi2()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var configuration = GlobalConfiguration.Configuration;
            
            // 註冊您的Web API控制器。
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //特別指定 AccountBController 的 IAccountService 要是 AccountBService
            builder.RegisterType<AccountBController>()
                .WithParameter(
                 new ResolvedParameter(
                   (pi, ctx) => pi.ParameterType == typeof(IAccountService),
                   (pi, ctx) => ctx.ResolveKeyed<IAccountService>(nameof(AccountBService))))
                .InstancePerRequest();
    
            RegisterCommon(builder);
            RegisterService(builder);
            RegisterRepo(builder);
            //註冊ActionFilter 也可以屬性注入 SingleInstance
            builder.RegisterWebApiFilterProvider(configuration);
            // 將依賴關係解析器(DependencyResolver)設置為Autofac。
            var container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        public static void RegisterMvc5()
        {
            var builder = new ContainerBuilder();

            // 註冊您的MVC控制器。 （MvcApplication是Global.asax中類的名稱。）
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            RegisterCommon(builder);
            RegisterService(builder);
            RegisterRepo(builder);
            

            //將依賴關係解析器(DependencyResolver)設置為Autofac。
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterRepo(ContainerBuilder builder)
        {
            builder.RegisterType<DemoRepository>().As<IDemoRepository>();
        }

        private static void RegisterService(ContainerBuilder builder)
        {
            builder.RegisterType<DemoSerive>().As<IDemoSerive>();
            
            builder.RegisterType<AccountAService>().As<IAccountService>().Keyed<IAccountService>(nameof(AccountAService));
            builder.RegisterType<AccountBService>().As<IAccountService>().Keyed<IAccountService>(nameof(AccountBService));
            builder.RegisterType<AccountCService>().As<IAccountService>().Keyed<IAccountService>(nameof(AccountCService));
            builder.RegisterType<AcountStrategy>().As<IAcountStrategy>();

        }

        private static void RegisterCommon(ContainerBuilder builder)
        {
            builder.RegisterType<AppSetting>().As<IAppSetting>().SingleInstance();
            builder.RegisterType<ComponentLocator>().As<IComponentLocator>();

        }
    }
}
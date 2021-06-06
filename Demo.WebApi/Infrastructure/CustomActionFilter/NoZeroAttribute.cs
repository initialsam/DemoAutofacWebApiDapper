using Demo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Demo.Common;
using System.Diagnostics;

namespace Demo.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class NoZeroAttribute : ActionFilterAttribute
    {
        public IDemoSerive DemoSerive { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
{
            Debug.WriteLine($"NoZeroAttribute MyGuid:{DemoSerive.MyGuid}");
            if (actionContext.ActionArguments["id"].ToString() == "0")
            {

                var happyString = DemoSerive.HappyString(666);
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.OK,
                    new { id = 0, HappyString = happyString },
                    actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
                    );
                return;
            }
            base.OnActionExecuting(actionContext);
        }

    }
}
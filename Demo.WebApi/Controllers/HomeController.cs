using Demo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.WebApi.Controllers
{
    /// <summary>
    /// 注意 這是MVC 並不是WebApi2
    /// </summary>
    public class HomeController : Controller
    {
        private IDemoSerive _demoSerive;
        public HomeController(IDemoSerive demoSerive)
        {
            _demoSerive = demoSerive;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.HappyString = _demoSerive.HappyString(77);
            return View();
        }
    }
}

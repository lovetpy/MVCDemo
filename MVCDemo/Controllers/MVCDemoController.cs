using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class MVCDemoController : Controller
    {
        // GET: MVCDemo
        public ActionResult Index()
        {
            ViewBag.DateTime = DateTime.Now;
            return View();
        }
        /// <summary>
        /// [ChildActionOnly]表示这个Action只应作为子操作进行调用。也就是说直接通过 controller/action这样的网址是不能访问的，会提示只能由子请求访问的错误
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult ShowWidget()
        {
            ViewBag.DateTime = DateTime.Now.AddMinutes(10);
            return PartialView("~/Views/Shared/_PartialPageWidget.cshtml");
        }
    }
}
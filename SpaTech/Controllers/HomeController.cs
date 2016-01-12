using SpaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaTech.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            TrainingProductViewModel vm = new TrainingProductViewModel();

            vm.HandleRequest();

            return View(vm);


        }
        
        [HttpPost]
        public ActionResult Index(TrainingProductViewModel vm)
        {
            vm.IsValid = ModelState.IsValid;
            vm.HandleRequest();

            if(vm.IsValid)
            {
                ModelState.Clear();
            }
            else
            {
                foreach(KeyValuePair<string,string> item in vm.ValidationErrors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
            }
            return View(vm);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using AnimalRegistration.Models;
using AnimalRegistration.AuthaData;

namespace AnimalRegistration.Controllers
{
    //[AuthAttribute]
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Animal()
        {
           
            return View();


        }


        public ActionResult Birds()
        {

            
            return View();


        }

        public ActionResult Mammals()
        {
            ViewBag.Message = "about the animal page.";

            return View();
        }

        public ActionResult AnimalFacts()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiscuitRating.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Where are you staying?";

            return View();
        }

        public ActionResult SelectHotel(int hotelId)
        {
            ViewBag.Message = "How are the biscuits at " + hotelId + "?";



            return View();
        }

        public ActionResult RateHotel()
        {
            ViewBag.Message = "Thanks for your review";

            return View();
        }
    }
}

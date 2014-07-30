using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult> SelectHotel()
        {
            ViewBag.Message = "How are the biscuits?";

            //var hotelDetails = new HotelDetailsApi()
             //   .FetchHotel(1234);

            ViewBag.HotelName = "Joe's Hotel";

            return View();
        }

        public ActionResult RateHotel()
        {
            ViewBag.Message = "Thanks for your review";

            return View();
        }
    }
}

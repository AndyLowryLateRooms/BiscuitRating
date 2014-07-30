using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BiscuitRating.Apis;

namespace BiscuitRating.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Where are you staying?";

            return View();
        }

        public async Task<ActionResult> SelectHotel(int hotelId)
        {
            try
            {
                System.Diagnostics.Trace.WriteLine("SelectHotel" + hotelId);

                var hotelDetails = await new HotelDetailsRepository()
                    .FetchHotel(hotelId);

                ViewBag.Message = "How are the biscuits at " + hotelDetails.Name + "?";
                ViewBag.Hotel = hotelDetails;

                return View();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Trace.WriteLine(exception);
                throw;
            }
        }

        public async Task<ActionResult> RateHotel(int hotelId, int rating)
        {
            var hotelDetails = await new HotelDetailsRepository()
                .FetchHotel(hotelId);

            ViewBag.Message = "Thankyou for reviewing " + hotelDetails.Name;
            ViewBag.Hotel = hotelDetails;
            ViewBag.Rating = rating;

            return View();
        }
    }
}

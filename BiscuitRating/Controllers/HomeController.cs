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
            var hotelDetails = await new HotelDetailsRepository()
                .FetchHotel(hotelId);

            ViewBag.Message = "How are the biscuits at " + hotelDetails.Name + "?";

            return View();
        }

        public ActionResult RateHotel()
        {
            ViewBag.Message = "Thanks for your review";

            return View();
        }
    }
}

using System;
using System.Threading.Tasks;
using BiscuitRating.Controllers;
using System.Net;

namespace BiscuitRating.Apis
{
    public class HotelDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class HotelDetailsRepository
    {
        public async Task<HotelDetails> FetchHotel(int hotelId)
        {
            var webClient = new WebClient();

            return new HotelDetails()
            {
                Id = hotelId,
                Name = "Bob's Hotel"
            };
        }
    }
}
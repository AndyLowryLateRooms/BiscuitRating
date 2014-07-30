using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
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
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("TLRG-AppId", "257B8C35-CD18-4A58-92AC-13EC6FBF78A3");
            client.BaseAddress = new Uri("http://api.laterooms.com/hotel/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(hotelId.ToString(CultureInfo.InvariantCulture));

            dynamic result = await response.Content.ReadAsAsync<object>();

            return new HotelDetails()
            {
                Id = hotelId,
                Name = result.name
            };
        }
    }
}
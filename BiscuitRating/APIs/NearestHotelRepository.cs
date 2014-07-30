using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;

namespace BiscuitRating.Apis
{
    public class NearestHotelRepository
    {
        public async Task<IEnumerable<HotelDetails>> FetchHotels(double latitude, double longitude)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("TLRG-AppId", "257B8C35-CD18-4A58-92AC-13EC6FBF78A3");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("http://api.laterooms.com/search/location/"
                + latitude.ToString(CultureInfo.InvariantCulture) + "," + longitude.ToString(CultureInfo.InvariantCulture) + "/?s=Distance");

            return await DecodeResponse(response);
        }

        private async Task<IEnumerable<HotelDetails>> DecodeResponse(HttpResponseMessage response)
        {
            var hotels = await GetHotelArray(response);

            return hotels.Select(hotel => DecodeHotel((JObject)hotel));
        }

        private async Task<List<object>> GetHotelArray(HttpResponseMessage response)
        {
            dynamic result = await response.Content.ReadAsAsync<object>();

            Trace(result.ToString());

            var hotels = result.results.ToObject<List<object>>();
            return hotels;
        }

        private HotelDetails DecodeHotel(JObject hotel)
        {
            dynamic result = hotel;
            return new HotelDetails()
                {
                    Id = result.id,
                    Name = result.name,
                    PhotoUrl = result.img
                };
        }

        private void Trace(string str)
        {
            System.Diagnostics.Trace.WriteLine(str, "HotelDetailRepo");
        }
    }
}
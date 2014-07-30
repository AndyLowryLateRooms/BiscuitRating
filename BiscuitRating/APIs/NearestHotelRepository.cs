using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;

namespace BiscuitRating.Apis
{
    public class NearestHotelRepository
    {
        public async Task<HotelDetails> FetchHotel(double latitude, double longitude)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("TLRG-AppId", "257B8C35-CD18-4A58-92AC-13EC6FBF78A3");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("http://api.laterooms.com/search/location/" + latitude.ToString(CultureInfo.InvariantCulture) + "," + longitude.ToString(CultureInfo.InvariantCulture) + "/");

            return await DecodeResponse(response);
        }

        private async Task<HotelDetails> DecodeResponse(HttpResponseMessage response)
        {
            dynamic result = await response.Content.ReadAsAsync<object>();

            Trace(result.ToString());

            return new HotelDetails()
            {
                Id = result.results[0].id,
                Name = result.results[0].name,
                PhotoUrl = result.results[0].img
            };
        }

        private void Trace(string str)
        {
            System.Diagnostics.Trace.WriteLine(str, "HotelDetailRepo");
        }
    }
}
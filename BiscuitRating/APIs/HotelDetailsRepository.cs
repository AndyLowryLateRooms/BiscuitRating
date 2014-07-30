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
        public string PhotoUrl { get; set; }
    }

    public class HotelDetailsRepository
    {
        public async Task<HotelDetails> FetchHotel(int hotelId)
        {
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("TLRG-AppId", "257B8C35-CD18-4A58-92AC-13EC6FBF78A3"); // api
            //client.BaseAddress = new Uri("http://api.laterooms.com/hotel/");
            client.DefaultRequestHeaders.Add("TLRG-AppId", "26F003D8-DFC3-480E-854B-9A3F439C0C8D"); // sandbox api
            client.BaseAddress = new Uri("http://sandbox.api.laterooms.com/hotel/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(hotelId.ToString(CultureInfo.InvariantCulture));

            return await DecodeResponse(hotelId, response);
        }

        private async Task<HotelDetails> DecodeResponse(int hotelId, HttpResponseMessage response)
        {
            dynamic result = await response.Content.ReadAsAsync<object>();

            Trace(result.ToString());

            return new HotelDetails()
            {
                Id = hotelId,
                Name = result.name,
                PhotoUrl = result.images.gallery[0].url
            };
        }

        private void Trace(string str)
        {
            System.Diagnostics.Trace.WriteLine(str, "HotelDetailRepo");
        }
    }
}
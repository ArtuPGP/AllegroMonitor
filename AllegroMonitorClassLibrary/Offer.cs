using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AllegroMonitorClassLibrary
{
    public class Offer
    {
        public async static Task<string> GetOffer(string phrase, string minPrice, string maxPrice, string sortType)
        {
            string url = $"https://api.allegro.pl/offers/listing?phrase={ phrase }&sort={ sortType }&price.from={ minPrice }&price.to={ maxPrice }";

            using HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}

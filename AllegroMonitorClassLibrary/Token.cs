using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AllegroMonitorClassLibrary
{
    public class Token
    {
        public async static Task<TokenModel> GetToken()
        {
            string url = "https://allegro.pl/auth/oauth/token?grant_type=client_credentials";

            using HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, new StringContent(string.Empty));
            if (response.IsSuccessStatusCode)
            {
                TokenModel tokenModel = await response.Content.ReadAsAsync<TokenModel>();

                return tokenModel;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}

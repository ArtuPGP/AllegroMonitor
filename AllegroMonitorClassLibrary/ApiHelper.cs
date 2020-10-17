using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AllegroMonitorClassLibrary
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        private static readonly string clientID = "9424b2fb0ea24476a026089ab9940d85";
        private static readonly string clientSecret = "X2mWqcYP0G8Q0Tpv7VEPi2y0c27weMMAZKVCFnm4GNJGaJFy4C00lTEDnlRXjBZd";

        public static void ClientInitialization()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));

            //// Dodanie nagłówka z loginem i hasłem do pobrania tokena autoryzującego ////
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ clientID }:{ clientSecret }")));
        }
    }
}

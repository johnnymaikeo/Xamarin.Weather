using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Xamarin.Weather.ViewModel
{
    class AddCityViewModel
    {
        public async void GetCityList(string name)
        {
            await FetchCitiesAsync(name);
        }

        public async Task FetchCitiesAsync(string name)
        {
            var url = string.Format("http://api.openweathermap.org/data/2.5/find?q={0}&type=like&sort=name", name);
            
            // Create an HTTP web request using the URL
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response
                using (Stream stream = response.GetResponseStream())
                {

                }
            }
        }
    }
}

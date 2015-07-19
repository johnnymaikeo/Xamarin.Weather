using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml.Linq;
using System.Linq;
using Xamarin.Weather.Model;

namespace Xamarin.Weather.ViewModel
{
    public class AddCityViewModel
    {
        public List<City> Cities { get; set; }

        public async Task GetCityList(string name)
        {
            await FetchCitiesAsync(name);
        }

        public async Task FetchCitiesAsync(string name)
        {
            var url = string.Format("http://servicos.cptec.inpe.br/XML/listaCidades?city={0}", name);

            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = string.Empty;
                
                XElement xml = XElement.Parse(await response.Content.ReadAsStringAsync());

                Cities = new List<City>();

                Cities = (from l in xml.Descendants("cidade")
                              select new City {
                                Id = Convert.ToInt32(l.Element("id").Value),
                                Name = l.Element("nome").Value
                              }).ToList();
            }
            catch (HttpRequestException e) 
            { 
                // Error
            }
        }
    }
}

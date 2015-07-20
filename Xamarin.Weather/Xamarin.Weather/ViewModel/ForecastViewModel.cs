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
    public class ForecastViewModel
    {
        public List<CityForecast> Forecasts { get; set; }

        public async Task GetExtendedForecast(int Id)
        {
            await FetchExtendedForecastAsync(Id);
        }

        private async Task FetchExtendedForecastAsync(int Id)
        {
            var url = string.Format("http://servicos.cptec.inpe.br/XML/cidade/{0}/estendida.xml", Convert.ToString(Id));

            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = string.Empty;

                XElement xml = XElement.Parse(await response.Content.ReadAsStringAsync());
                this.Forecasts = new List<CityForecast>();
                this.Forecasts = (from l in xml.Descendants("previsao")
                                  select new CityForecast
                                  {
                                      Dia = l.Element("dia").Value,
                                      Tempo = l.Element("tempo").Value,
                                      Maxima = l.Element("maxima").Value,
                                      Minima = l.Element("minima").Value,
                                  }).ToList();

            }
            catch (HttpRequestException e)
            {
                // Error
            }
        }
    }
}

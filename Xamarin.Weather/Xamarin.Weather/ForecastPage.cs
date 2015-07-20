using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Weather.Model;
using Xamarin.Weather.ViewModel;

namespace Xamarin.Weather
{
    class Forecast : ContentPage 
    {
        public Forecast() 
        {
            this.Title = "Extended Forecast";

            this.Appearing += ContentPage_Appearing;
        }

        private void ContentPage_Appearing(object sender, EventArgs args)
        {
            City myCity = this.GetMyCity();

            if (myCity != null)
            {
                this.LoadExtendedForecast(myCity);
            }
            else
            {
                // show information to user add a new city
            }
        }

        private City GetMyCity()
        {
            foreach (City c in App.Cities)
            {
                if (c.IsMyCity == true)
                {
                    return c;
                }
            }

            return null;
        }

        private async void LoadExtendedForecast(City myCity)
        {
            ForecastViewModel vm = new ForecastViewModel();
            await vm.GetExtendedForecast(myCity.Id);

            Label labelCityName = new Label();
            labelCityName.Text = myCity.Name;

            Label labelData = new Label();
            labelData.SetBinding(Label.TextProperty, "Dia");

            Label labelMaxima = new Label();
            labelMaxima.SetBinding(Label.TextProperty, "Maxima");

            Label labelMinima = new Label();
            labelMinima.SetBinding(Label.TextProperty, "Minima");

            ListView listViewForecast = new ListView();
            listViewForecast.ItemTemplate = new DataTemplate(() =>
            {
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children = 
                        {
                            labelData,
                            labelMaxima,
                            labelMinima
                        }
                    }
                };
            });

            this.Content = new StackLayout
            {
                Children =
                    {
                        labelCityName,
                        listViewForecast
                    }
            };

            listViewForecast.ItemsSource = vm.Forecasts;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Weather.Model;
using Xamarin.Weather.ViewModel;

namespace Xamarin.Weather
{
    class Now : ContentPage
    {
        public Now()
        {
            this.Title = "Forecast";

            this.Appearing += ContentPage_Appearing;
        }

        private void ContentPage_Appearing(object sender, EventArgs args)
        {
            City myCity = this.GetMyCity();

            if (myCity != null)
            {
                this.LoadCityForecast(myCity);
            }
            else
            {
                // show information to user add a new city
            }
        }

        private async void LoadCityForecast(City city)
        {
            NowViewModel vm = new NowViewModel();
            await vm.GetForecast(city.Id);

            Label labelCityName = new Label();
            labelCityName.Text = city.Name;

            ListView listViewForecast = new ListView();
            listViewForecast.ItemTemplate = new DataTemplate(() =>
            {
                Label labelData = new Label();
                labelData.SetBinding(Label.TextProperty, "Dia");

                Label labelMaxima = new Label();
                labelMaxima.SetBinding(Label.TextProperty, "Maxima");

                Label labelMinima = new Label();
                labelMinima.SetBinding(Label.TextProperty, "Minima");

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

            listViewForecast.BindingContext = vm.Forecasts;

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
    }
}

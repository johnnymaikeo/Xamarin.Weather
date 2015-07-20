using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Weather.Model;
using Xamarin.Weather.ViewModel;

namespace Xamarin.Weather
{
    class Places : ContentPage
    {
        public Places() 
        {
            
            this.Title = "My Places";

            this.Appearing += ContentPage_Appearing;
        }

        private void ContentPage_Appearing(object sender, EventArgs args)
        { 
            if (App.Cities.Count > 1)
            {
                this.LoadForecastForMyPlaces();
            }
        }

        private async void LoadForecastForMyPlaces()
        {
            ListView listView = new ListView();
            List<PlacesWeather> listPlaces = new List<PlacesWeather>();

            foreach (City c in App.Cities)
            {
                if (c.IsMyCity == false)
                {
                    PlacesViewModel vm = new PlacesViewModel();
                    await vm.GetForecast(c.Id);
                    PlacesWeather place = new PlacesWeather
                    {
                        CityName = c.Name,
                        DayOne = vm.Forecasts[0].Dia,
                        DayOneMax = vm.Forecasts[0].Maxima,
                        DayOneMin = vm.Forecasts[0].Minima,
                        DayTwo = vm.Forecasts[1].Dia,
                        DayTwoMax = vm.Forecasts[1].Maxima,
                        DayTwoMin = vm.Forecasts[1].Minima
                    };
                    listPlaces.Add(place);
                }
            }

            listView.ItemTemplate = new DataTemplate(() =>
            {
                Label labelCityName = new Label();
                labelCityName.SetBinding(Label.TextProperty, "CityName");
                Label labelDayOne = new Label();
                labelDayOne.SetBinding(Label.TextProperty, "DayOne");
                Label labelDayOneMax = new Label();
                labelDayOneMax.SetBinding(Label.TextProperty, "DayOneMax");
                Label labelDayOneMin = new Label();
                labelDayOneMin.SetBinding(Label.TextProperty, "DayOneMin");
                Label labelDayTwo = new Label();
                labelDayTwo.SetBinding(Label.TextProperty, "DayTwo");
                Label labeDayTwoMax = new Label();
                labeDayTwoMax.SetBinding(Label.TextProperty, "DayTwoMax");
                Label labelDayTwoMin = new Label();
                labelDayTwoMin.SetBinding(Label.TextProperty, "DayTwoMin");
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Vertical,
                        Children = 
                        {
                            labelCityName,
                            new StackLayout 
                            {
                                Padding = new Thickness(0, 5),
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    labelDayOne,
                                    labelDayOneMax,
                                    labelDayOneMin
                                }
                            },
                            new StackLayout 
                            {
                                Padding = new Thickness(0, 5),
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    labelDayOne,
                                    labelDayOneMax,
                                    labelDayOneMin
                                }
                            },
                        }
                    }
                };
            });

            listView.ItemsSource = listPlaces;

            this.Content = new StackLayout
            {
                Children = 
                {
                    listView
                }
            };
        }
    }
}

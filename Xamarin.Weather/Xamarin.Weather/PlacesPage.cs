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
            List<StackLayout> listOfListViews = new List<StackLayout>();

            StackLayout stackLayout = new StackLayout();

            foreach (City c in App.Cities)
            {
                PlacesViewModel vm = new PlacesViewModel();
                await vm.GetForecast(c.Id);

                Label labelCityName = new Label
                {
                    Text = c.Name
                };

                Label labelFirstDate = new Label
                {
                    Text = vm.Forecasts[0].Dia
                };

                Label labelFirstMin = new Label
                {
                    Text = vm.Forecasts[0].Minima
                };

                Label labelFirstMax = new Label
                {
                    Text = vm.Forecasts[0].Maxima
                };

                Label labelSecondDate = new Label
                {
                    Text = vm.Forecasts[1].Dia
                };

                Label labelSecondMin = new Label
                {
                    Text = vm.Forecasts[1].Minima
                };

                Label labelSecondMax = new Label
                {
                    Text = vm.Forecasts[1].Dia
                };

                StackLayout stackLayoutFirstDay = new StackLayout 
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = 
                    {
                        labelFirstDate,
                        labelFirstMin,
                        labelFirstMax,
                    }
                };

                StackLayout stackLayoutSecondDay = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = 
                    {
                        labelSecondDate,
                        labelSecondMin,
                        labelSecondMax
                    }
                };

                stackLayout = new StackLayout
                {
                    Spacing = 10,
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.End,
                    Children = 
                    {
                        labelCityName,
                        stackLayoutFirstDay,
                        stackLayoutSecondDay,
                    }
                };

                listOfListViews.Add(stackLayout);
            }

            ListView ListViewOfPlaces = new ListView();

            ListViewOfPlaces.ItemTemplate = new DataTemplate(() =>
            {
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Spacing = 10,
                        VerticalOptions = LayoutOptions.End,
                        Children = 
                        {
                            stackLayout
                        }
                    }
                };
            });

            ListViewOfPlaces.ItemsSource = listOfListViews;
            this.Content = new StackLayout
            {
                Spacing = 10,
                VerticalOptions = LayoutOptions.End,
                Children =
                    {
                        ListViewOfPlaces
                    }
            };
        }
    }
}

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

        private void LoadForecastForMyPlaces()
        {
            List<StackLayout> listOfListViews = new List<StackLayout>();

            StackLayout stackLayout = new StackLayout();

            foreach (City c in App.Cities)
            {
                PlacesViewModel vm = new PlacesViewModel();
                vm.GetForecast(c.Id);

                Label labelCityName = new Label
                {
                    Text = c.Name
                };

                stackLayout = new StackLayout
                {
                    Spacing = 10,
                    Orientation = StackOrientation.Vertical,
                    VerticalOptions = LayoutOptions.End,
                    Children = 
                    {
                        labelCityName,
                        new StackLayout 
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children = 
                            {
                                new Label {
                                    Text = vm.Forecasts[0].Dia
                                },
                                new Label {
                                    Text = vm.Forecasts[0].Minima
                                },
                                new Label {
                                    Text = vm.Forecasts[0].Maxima
                                },
                            }
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children = 
                            {
                                new Label {
                                    Text = vm.Forecasts[1].Dia
                                },
                                new Label {
                                    Text = vm.Forecasts[1].Minima
                                },
                                new Label {
                                    Text = vm.Forecasts[1].Maxima
                                },
                            }
                        },
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

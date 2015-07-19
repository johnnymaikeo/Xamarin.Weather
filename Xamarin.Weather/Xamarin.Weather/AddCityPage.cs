using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Weather.Model;
using Xamarin.Weather.ViewModel;

namespace Xamarin.Weather
{
    class AddCityPage : ContentPage
    {
        Entry EntryCityName;
        ListView ListViewCities;

        public AddCityPage()
        {
            Label pageTitle = new Label {
                Text = "Add City",
                FontSize = 56
            };

            this.EntryCityName = new Entry
            {
                Placeholder = "City Name",
            };

            this.EntryCityName.TextChanged += CityName_TextChanged;

            this.ListViewCities = new ListView();

            this.ListViewCities.ItemTapped += (sender, e) =>
            {
                City selectedCity = (City)((ListView)sender).SelectedItem;

                if (App.Cities.Count == 0) 
                {
                    selectedCity.IsMyCity = true;
                }

                App.Cities.Add(selectedCity);
                // Return to previous page
                Navigation.PopAsync();
            };

            this.ListViewCities.ItemTemplate = new DataTemplate(() => 
            {
                Label labelCityName = new Label();
                labelCityName.SetBinding(Label.TextProperty, "Name");

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children = 
                        {
                            labelCityName
                        }
                    }
                };
            });

            this.Content = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    pageTitle,
                    this.EntryCityName,
                    this.ListViewCities
                }
            };

            ToolbarItem cancelToolbarItem = new ToolbarItem();
            cancelToolbarItem.Text = "Cancel";
            cancelToolbarItem.Command = new Command(() =>
            {
                Navigation.PopAsync();
            });

            this.ToolbarItems.Add(cancelToolbarItem);
        }

        public async void CityName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.EntryCityName.Text.Length >= 3)
            { 
                AddCityViewModel vm = new AddCityViewModel();
                await vm.GetCityList(this.EntryCityName.Text);
                this.ListViewCities.ItemsSource = vm.Cities;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using Xamarin.Weather.ViewModel;

namespace Xamarin.Weather
{
    class AddCityPage : ContentPage
    {
        Entry CityName;

        public AddCityPage()
        {
            Label pageTitle = new Label {
                Text = "Add City",
                FontSize = 42
            };

            this.CityName = new Entry
            {
                Placeholder = "City Name",
            };

            this.CityName.TextChanged += CityName_TextChanged;

            this.Content = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    pageTitle,
                    this.CityName
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

        public void CityName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.CityName.Text.Length >= 3) { 
                AddCityViewModel vm = new AddCityViewModel();
                vm.GetCityList(this.CityName.Text);
            }
        }
    }
}

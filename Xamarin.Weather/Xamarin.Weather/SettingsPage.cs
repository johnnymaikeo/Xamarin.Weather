using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Weather.ViewModel;
using Xamarin.Weather.Model;

namespace Xamarin.Weather
{
    class SettingsPage : ContentPage
    {
        ListView ListViewMyCities;

        public SettingsPage()
        {
            this.Title = "Settings";

            Label pageTitle = new Label
            {
                Text = "Settings",
                FontSize = 56
            };

            ListViewMyCities = new ListView();

            ListViewMyCities.ItemTemplate = new DataTemplate(() =>
            {
                Label labelCityName = new Label();
                labelCityName.SetBinding(Label.TextProperty, "Name");

                Label labelMyCity = new Label();
                labelMyCity.SetBinding(Label.TextProperty, "IsMyCity");

                StackLayout line = new StackLayout
                {
                    Padding = new Thickness(0, 5),
                    Orientation = StackOrientation.Vertical,
                    Children =
                    {
                        labelCityName,
                        labelMyCity
                    }
                };

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children = 
                        {
                            line
                        }
                    }
                };
            });

            ListViewMyCities.ItemTapped += ListViewItem_Tapped;

            ListViewMyCities.ItemsSource = App.Cities;

            this.Content = new StackLayout
            {
                Children =
                {
                    pageTitle,
                    ListViewMyCities
                }
            };

            ToolbarItem settingsToolbarItem = new ToolbarItem();
            settingsToolbarItem.Text = "Return";
            settingsToolbarItem.Command = new Command(() =>
            {
                Navigation.PopAsync();
            });

            ToolbarItem addToobarItem = new ToolbarItem();
            addToobarItem.Text = "Add City";
            addToobarItem.Command = new Command(() =>
            {
                // Push to Add City Page
                Navigation.PushAsync(new AddCityPage());
            });

            this.ToolbarItems.Add(settingsToolbarItem);
            this.ToolbarItems.Add(addToobarItem);
        }

        async void ListViewItem_Tapped(object sender, EventArgs args)
        {
            var action = await DisplayActionSheet("Action:", "Cancel", null, "Set as MyCity", "Delete");

            City selectedCity = (City)((ListView)sender).SelectedItem;
            SettingsViewModel vm = new SettingsViewModel();

            if (action.ToString() == "Set as MyCity")
            {
                vm.SetCityAsMyCity(selectedCity);
            }
            else if (action.ToString() == "Delete")
            {
                vm.DeleteCity(selectedCity);
            }

            ListViewMyCities.ItemsSource = null;
            ListViewMyCities.ItemsSource = App.Cities;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Weather
{
    class AddCityPage : ContentPage
    {
        public AddCityPage()
        {
            Label pageTitle = new Label();
            pageTitle.Text = "Add City";

            this.Content = new StackLayout
            {
                Children =
                {
                    pageTitle,
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
    }
}

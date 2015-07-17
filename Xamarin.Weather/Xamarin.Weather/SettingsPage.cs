using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Weather
{
    class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            this.Title = "Settings";

            Label pageTitle = new Label();
            pageTitle.Text = "Settings";

            this.Content = new StackLayout
            {
                Children =
                {
                    pageTitle,
                }
            };

            ToolbarItem settingsToolbarItem = new ToolbarItem();
            settingsToolbarItem.Text = "Cancel";
            settingsToolbarItem.Command = new Command(() =>
            {
                Navigation.PopAsync();
            });

            ToolbarItem saveToobarItem = new ToolbarItem();
            saveToobarItem.Text = "Save";
            saveToobarItem.Command = new Command(() =>
            {
                // Save
            });

            ToolbarItem addToobarItem = new ToolbarItem();
            addToobarItem.Text = "Add City";
            addToobarItem.Command = new Command(() =>
            {
                // Push to Add City Page
                Navigation.PushAsync(new AddCityPage());
            });

            this.ToolbarItems.Add(settingsToolbarItem);
            this.ToolbarItems.Add(saveToobarItem);
            this.ToolbarItems.Add(addToobarItem);
        }
    }
}

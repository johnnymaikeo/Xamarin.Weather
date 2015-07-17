using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Weather
{
    class StartTabbedPage : TabbedPage
    {
        public StartTabbedPage()
        {
            this.Title = "Cross Weather";
            this.Children.Add(new Now());
            this.Children.Add(new Forecast());
            this.Children.Add(new Places());

            ToolbarItem settingsToolbarItem = new ToolbarItem();
            settingsToolbarItem.Text = "Settings";
            settingsToolbarItem.Command = new Command(() =>
            {
                Navigation.PushAsync(new SettingsPage());
            });
            this.ToolbarItems.Add(settingsToolbarItem);
        }
    }
}

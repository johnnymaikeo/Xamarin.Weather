using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Weather.Model;

namespace Xamarin.Weather.ViewModel
{
    public class SettingsViewModel
    {
        public void SetCityAsMyCity(City city)
        {
            foreach (City c in App.Cities)
            {
                if (c.Id == city.Id)
                {
                    c.IsMyCity = true;
                }
                else
                { 
                    c.IsMyCity = false;
                }
            }
        }

        public void DeleteCity(City city)
        {
            int count = 0;
            foreach (City c in App.Cities)
            {
                if (c.Id == city.Id)
                {
                    break;
                }
                count++;
            }

            App.Cities.RemoveAt(count);
        }
    }
}

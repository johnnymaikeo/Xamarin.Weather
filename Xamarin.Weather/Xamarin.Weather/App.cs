using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Weather.Model;

namespace Xamarin.Weather
{
	public class App : Application
	{
        public static List<City> Cities = new List<City>();

		public App ()
		{
			// The root page of your application
            MainPage = new NavigationPage(new StartTabbedPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

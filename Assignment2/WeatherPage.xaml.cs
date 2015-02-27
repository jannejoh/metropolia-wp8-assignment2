using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Assignment2
{
    /// <summary>
    /// Weather page displaying current weather.
    /// </summary>
    public sealed partial class WeatherPage : Page
    {
        private Models.RootObject weather = null;
        private Common.NavigationHelper navigationHelper = null;

        public WeatherPage()
        {
            this.InitializeComponent();

            navigationHelper = new Common.NavigationHelper(this);
        }

        private void NavigationHelper_LoadState(object sender, Common.LoadStateEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Weather - load state");

            // load data directly from local settings
            Windows.Storage.ApplicationDataContainer localSettings
                = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey("Val"))
            {
                weather = Utils.JsonHelper.Deserialize<Models.RootObject>(localSettings.Values["Val"] as string);
                UpdateUI();
            }

            // load data from helper class
            if(e.PageState != null)
            {
               if(e.PageState.ContainsKey("VAL"))
               {
                   weather = Utils.JsonHelper.Deserialize<Models.RootObject>(e.PageState["VAL"] as string);
                   UpdateUI();
               }
            }
        }

        private void NavigationHelper_SaveState(object sender, Common.SaveStateEventArgs e)
        {
            // save data
            e.PageState["VAL"] = Utils.JsonHelper.Serialize(weather); 
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper = new Common.NavigationHelper(this);
            navigationHelper.SaveState += NavigationHelper_SaveState;
            navigationHelper.LoadState += NavigationHelper_LoadState;

            navigationHelper.OnNavigatedTo(e);

            if (e.Parameter is string)
            {
                weather = Utils.JsonHelper.Deserialize<Models.RootObject>(e.Parameter as string);
                Windows.Storage.ApplicationDataContainer localSettings 
                        = Windows.Storage.ApplicationData.Current.LocalSettings;
                localSettings.Values["Val"] = Utils.JsonHelper.Serialize(weather);
                UpdateUI();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }
        
        private void UpdateUI()
        {
            Models.Item WeatherItem = weather.query.results.channel.item;
            TitleNow.Text = WeatherItem.title;
            ConditionNow.Text = WeatherItem.condition.temp + " °C, " + WeatherItem.condition.text;
            if(WeatherItem.forecast.Count >= 2)
            {
                Models.Forecast tomorrowsForecast = WeatherItem.forecast[1];
                TitleTomorrow.Text = tomorrowsForecast.date;
                ConditionTomorrow.Text = tomorrowsForecast.low + " °C ... " + tomorrowsForecast.high + " °C, " + tomorrowsForecast.text;
            }
            else
            {
                TitleTomorrow.Text = "";
                ConditionTomorrow.Text = "";
            }
        }

    }
}

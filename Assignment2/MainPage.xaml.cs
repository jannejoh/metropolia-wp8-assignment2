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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Assignment2
{
    public sealed partial class MainPage : Page
    {
        private const string CityQueryUrl = "https://query.yahooapis.com/v1/public/yql?q=select%20item%20from%20weather.forecast%20where%20woeid%20in%20%28select%20woeid%20from%20geo.places%281%29%20where%20text=%27{0}%27%29%20and%20u='c'&format=json";
        private const string WoeidQueryUrl = "https://query.yahooapis.com/v1/public/yql?q=select%20item%20from%20weather.forecast%20where%20woeid={0}%20and%20u='c'&format=json";

        private Common.NavigationHelper navigationHelper = null;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            navigationHelper = new Common.NavigationHelper(this);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text))
            {
                //do nothing
                return;
            }
            int woeid = 0;
             
            if (int.TryParse(SearchBox.Text, out woeid))
            {
                // search by woeid
                await FireHttpGetWeatherInfo(string.Format(WoeidQueryUrl, woeid));
            }
            else
            {
                // search by name
                await FireHttpGetWeatherInfo(string.Format(CityQueryUrl, SearchBox.Text));
            }
        }

        private async System.Threading.Tasks.Task<int> FireHttpGetWeatherInfo(string url)
        {
            using (var client = new Windows.Web.Http.HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(new Uri(url)))
                    {
                        // status code 200
                        if (response.StatusCode == Windows.Web.Http.HttpStatusCode.Ok)
                        {
                            var respMsg = await response.Content.ReadAsStringAsync();

                            Models.RootObject weather = Utils.JsonHelper.Deserialize<Models.RootObject>(respMsg);
                            if (weather.query.count == 0 || weather.query.results.channel.item.title.Equals("City not found"))
                            {
                                NoResults.Visibility = Windows.UI.Xaml.Visibility.Visible;
                            }
                            else
                            {
                                NoResults.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                                Frame.Navigate(typeof(WeatherPage), respMsg);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("http get response error: " + e.Message);
                }
            }
            return 1;
        }

    }
}

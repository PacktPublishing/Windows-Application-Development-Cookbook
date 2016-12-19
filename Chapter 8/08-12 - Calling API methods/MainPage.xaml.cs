/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Calling API methods.
*/

using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH08
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnGET_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage responseMessage = await client.GetAsync(new Uri("http://jamro.biz/book/users.php"));
                string responseJson = await responseMessage.Content.ReadAsStringAsync();
                SearchResponse response = JsonConvert.DeserializeObject<SearchResponse>(responseJson);
                TxtResult.Text = string.Format(
                    "{0} user(s) found with {1:F2} as an average age.",
                    response.Users.Count,
                    response.Users.Average(u => u.Age));
            }
            catch (HttpRequestException)
            {
                TxtResult.Text = "Cannot get the results.";
            }
            catch (JsonReaderException)
            {
                TxtResult.Text = "Cannot parse the response.";
            }
        }

        private async void BtnPOST_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchRequestParameters parameters = new SearchRequestParameters()
                {
                    Login = "mar",
                    MinimumAge = 25,
                    MaximumAge = 30
                };
                string parametersJson = JsonConvert.SerializeObject(parameters);
                StringContent stringContent = new StringContent(parametersJson, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage responseMessage = await client.PostAsync(new Uri("http://jamro.biz/book/users.php"), stringContent);
                string responseJson = await responseMessage.Content.ReadAsStringAsync();
                SearchResponse response = JsonConvert.DeserializeObject<SearchResponse>(responseJson);
                TxtResult.Text = string.Format(
                    "{0} user(s) found with {1:F2} as an average age.",
                    response.Users.Count,
                    response.Users.Average(u => u.Age));
            }
            catch (HttpRequestException)
            {
                TxtResult.Text = "Cannot get the results.";
            }
            catch (JsonReaderException)
            {
                TxtResult.Text = "Cannot parse the response.";
            }
        }
    }
}

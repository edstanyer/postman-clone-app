using PostmanCloneLibrary;
using PostmanCloneLibrary.Models;
using PostmanCloneLibrary.Models.Settings;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string STATUS_READY = "Ready";
        private const string STATUS_LOADING = "Calling API...";
        private const string STATUS__INVALID_URL = "Invalid URL!";
        private const string STATUS_ERROR = "An error occurred";
        private const string STATUS_INVALID_VERB = "Invalid Http Verb Selection!";


        public MainWindow()
        {
            InitializeComponent();
            cache = new APICallCache("api_cache.json");

            httpVerbList.ItemsSource = Enum.GetValues(typeof(HTTPAction));

            httpVerbList.SelectedItem = HTTPAction.GET;
        }


      
        private readonly IAPIAccess api = new APIAccess();

        private APICallCache cache = new APICallCache("api_cache.json");

        List<string> urls = new List<string>();



        private async void getButton_Click(object sender, RoutedEventArgs e)
        {

            string inputText = urlBox.Text;

            //validate URL
            if (ValidationHelper.IsValidUrl(inputText) == false)
            {
                await setMessage(STATUS__INVALID_URL, null, 0);
                MessageBox.Show("Please enter a valid URL");
                return;
            }

            try
            {

                HTTPAction action;
                if (Enum.TryParse(httpVerbList.SelectedItem!.ToString(), out action) == false)
                {
                    await setMessage(STATUS_INVALID_VERB, null, 0);
                    MessageBox.Show("Invalid HTTP Verb selected");
                    return;
                }

                await setMessage(STATUS_LOADING, null, 20);
                string body = action != HTTPAction.GET ? bodyBox.Text : String.Empty;

                var response = await api.CallAPI(inputText, action, body, true);
                if (response.Item1 == true)
                { 


                    APIModel model = new APIModel(inputText, action, body);
                    cache.AddAPI(model);

                    resultsBox.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    resultsTab.Background = new SolidColorBrush(Colors.DarkGreen);

                }
                else
                {
                    resultsBox.Foreground= new SolidColorBrush(Colors.DarkRed);
                    resultsTab.Background = new SolidColorBrush(Colors.DarkRed);
                    await setMessage(STATUS_ERROR, response.Item2, 1000);

                }

                resultsBox.Text = response.Item2;
                callData.SelectedItem = resultsTab;


                callData.Focus();



                await setMessage(STATUS_READY, response.Item2, 0);
            }
            catch (Exception ex)
            {
                await setMessage(STATUS_ERROR);
                resultsBox.Text = "Error: " + ex.Message;
            }
        }

        private async Task setMessage(string message, string? response = null, int delay = 500)
        {


            systemStatus.Text = message;

            await Task.Delay(delay);

        }

        private void urlBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void urlBox_Enter(object sender, EventArgs e)
        {
            urlBox.SelectAll();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            httpVerbList.SelectedIndex = 0;


            if (urls.Count > 0)
            {
                urlBox.Text = urls[urls.Count() - 1];
            }

        }





        private void httpVerbList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var s = httpVerbList.SelectedItem;

            getButton.Content = s != null ? s.ToString() : "GET";

            callData.SelectedItem = bodyTab;
            resultsBox.Text = String.Empty;

            if (cache != null)
            {

                //get the existing API model from the cache
                IAPIModel? model = null;
                switch (s)
                {
                    case HTTPAction.GET:
                        model = cache.Get;
                        break;
                    case HTTPAction.POST:
                        model = cache.Post;
                        break;
                    case HTTPAction.PUT:
                        model = cache.Put;
                        break;
                    case HTTPAction.PATCH:
                        model = cache.Patch;
                        break;
                    case HTTPAction.DELETE:
                        model = cache.Delete;
                        break;
                }
                if (model != null)
                {
                    urlBox.Text = model.Url;
                    bodyBox.Text = model.Content;
                }
            }

        }
    }
}

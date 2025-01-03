using PostmanCloneLibrary;
using PostmanCloneLibrary.Models;
using PostmanCloneLibrary.Models.Settings;

namespace PostmanCloneUI
{
    public partial class Dashboard : Form
    {
        private const string STATUS_READY = "Ready";
        private const string STATUS_LOADING = "Calling API...";
        private const string STATUS__INVALID_URL = "Invalid URL!";
        private const string STATUS_ERROR = "An error occurred";
        private const string STATUS_INVALID_VERB = "Invalid Http Verb Selection!";

        private readonly IAPIAccess api = new APIAccess();

        private APICallCache cache = new APICallCache("api_cache.json");

        List<string> urls = new List<string>();

        public Dashboard()
        {
            InitializeComponent();
            cache = new APICallCache("api_cache.json");
            httpVerbList.SelectedItem = "GET";
             
        }

        private async void getButton_Click(object sender, EventArgs e)
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
                    

                    APIModel model = new APIModel( inputText, action,body);
                    cache.AddAPI(model);

                    resultsBox.ForeColor = Color.DarkGreen;
                    resultsTab.BackColor= Color.DarkGreen;
                   
                }
                else
                {
                    resultsBox.ForeColor = Color.DarkRed;
                    resultsTab.BackColor = Color.DarkRed;
                    await setMessage(STATUS_ERROR, response.Item2, 1000);

                }

                resultsBox.Text = response.Item2;
                callData.SelectedTab = resultsTab;
                

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



        private void httpVerbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = httpVerbList.SelectedItem;

            getButton.Text = s!=null? s.ToString(): "GET";

            callData.SelectedTab = bodyTab;
            resultsBox.Text = String.Empty;

            if ( cache != null)
            {

                //get the existing API model from the cache
                APIModel? model = null;
                switch (s)
                {
                    case "GET":
                        model = cache.Get;
                        break;
                    case "POST":
                        model = cache.Post;
                        break;
                    case "PUT":
                        model = cache.Put;
                        break;
                    case "PATCH":
                        model = cache.Patch;
                        break;
                    case "DELETE":
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

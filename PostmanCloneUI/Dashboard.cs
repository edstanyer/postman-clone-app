using PostmanCloneLibrary;

namespace PostmanCloneUI
{
    public partial class Dashboard : Form
    {
        private const string STATUS_READY = "Ready";
        private const string STATUS_LOADING = "Calling API...";
        private const string STATUS__INVALID_URL = "Invalid URL!";
        private const string STATUS_ERROR = "An error occurred";

        private readonly APIAccess api = new();

        public Dashboard()
        {
            InitializeComponent();
        }

        private async void getButton_Click(object sender, EventArgs e)
        {

            string inputText = urlBox.Text;

            //validate URL
            if (ValidationHelper.IsValidUrl(inputText) == false)
            {
                setMessage(STATUS__INVALID_URL);
                MessageBox.Show("Please enter a valid URL");
                return;
            }

            try
            {

                setMessage(STATUS_LOADING);

                
                var response = await api.CallAPI(inputText, HTTPAction.GET, String.Empty, true);
                if (response.Item1 == true)
                {
                    resultsBox.ForeColor = Color.DarkGreen;
                }
                else
                {
                    resultsBox.ForeColor = Color.DarkRed;
                }

                resultsBox.Text = response.Item2;


                //Sample code to call an API
                await Task.Delay(2000);

                setMessage(STATUS_READY);
            }
            catch (Exception ex)
            {
                setMessage(STATUS_ERROR);
                resultsBox.Text = "Error: " + ex.Message;
            }
        }

        private async void setMessage(string message, string? response = null)
        {


            systemStatus.Text = message;



            await Task.Delay(3000);




        }

        private void urlBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void urlBox_Enter(object sender, EventArgs e)
        {
            urlBox.SelectAll();
        }
    }


}

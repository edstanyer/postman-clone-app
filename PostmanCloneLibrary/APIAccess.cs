
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using static PostmanCloneLibrary.ValidationHelper;
using static PostmanCloneLibrary.Formatter;

namespace PostmanCloneLibrary;



public class APIAccess
{

    private readonly HttpClient client = new();

    public async Task<Tuple<bool, string>> CallAPI(string url)
    {
        //Sample code to call an API
       
        var response = await client.GetAsync(url);

        return await AssessResponse(response);  
    }

    public async Task<Tuple<bool, string>> CallAPI(string url, HTTPAction action, string body, bool formatOutput = true)
    {
        
        var content = new StringContent(body, Encoding.UTF8, "application/json");
        HttpResponseMessage? response = null;
        switch (action.ToString())
        {
            case "GET":
                response = await client.GetAsync(url);
                break;
            case "POST":
                response = await client.PostAsync(url, content);
                break;
            case "PUT":
                response = await client.PutAsync(url, content);
                break;
            case "DELETE":
                response = await client.DeleteAsync(url);
                break;
        }


        return await AssessResponse(response, formatOutput);
    }

    public async Task<Tuple<bool, string>> AssessResponse(HttpResponseMessage? response, bool formatOutput = true)
    {
        if (response == null)
        {
            return new Tuple<bool, string>(false, "No response received.");
        }

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            ResponseType typ = GetResponseType(responseContent);

            string output = formatOutput? FormatResponse( responseContent) : responseContent;

            
            return new Tuple<bool, string>(true, output);

        }
        else
        {
            return new Tuple<bool, string>(false, $"An error occurred. {Environment.NewLine}Status Code: {response.StatusCode + Environment.NewLine}" +
                                            $"Response Content: {response.Content + Environment.NewLine}" +
                                            $"Server Headers {response.Headers}");

        }

        
    }

}

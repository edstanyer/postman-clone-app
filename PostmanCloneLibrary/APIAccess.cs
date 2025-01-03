
using System.Runtime.CompilerServices;
using System.Text;

using static PostmanCloneLibrary.ValidationHelper;
using static PostmanCloneLibrary.Formatter;

namespace PostmanCloneLibrary;



public class APIAccess : IAPIAccess
{
    private readonly HttpClient client = new();

    public async Task<Tuple<bool, string>> CallAPI(string url, HTTPAction action, string content, bool formatOutput = true)
    {
        var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
        return await CallAPI(url, action, stringContent, formatOutput);

    }

    public async Task<Tuple<bool, string>> CallAPI(string url, HTTPAction action, StringContent content, bool formatOutput = true)
    {

        if (!IsValidMethod(action))
        {
            return new Tuple<bool, string>(false, "Invalid HTTP Verb");
        }


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
            case "PATCH":
                response = await client.PatchAsync(url, content);
                break;
            case "DELETE":
                response = await client.DeleteAsync(url);
                break;
        }

        return await AssessResponse(response, formatOutput);
    }

    private async Task<Tuple<bool, string>> AssessResponse(HttpResponseMessage? response, bool formatOutput = true)
    {
        if (response == null)
        {
            return new Tuple<bool, string>(false, "No response received.");
        }

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            ResponseType typ = GetResponseType(responseContent);

            string output = formatOutput ? FormatResponse(responseContent) : responseContent;


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

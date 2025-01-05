using System.Text.Json.Serialization;

namespace PostmanCloneLibrary.Models;

[Serializable]
public class APIModel : IAPIModel
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public HTTPAction Method
    {
        get;
        set;
    }

    [JsonPropertyName("body")]
    public string Content { get; set; }

    public APIModel(string url, HTTPAction method, string content)
    {
        Url = url;
        Method = method;
        Content = content;
    }

    public APIModel()
    {
        Url = String.Empty;
        Content = String.Empty;
        Method = HTTPAction.GET;
    }
}

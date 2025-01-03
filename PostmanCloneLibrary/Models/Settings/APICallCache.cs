
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PostmanCloneLibrary.Models.Settings;

[Serializable]
public class APICallCache
{
    [JsonPropertyName("get")]
    public APIModel Get { get; set; }
    [JsonPropertyName("post")]
    public APIModel Post { get; set; }
    [JsonPropertyName("put")]
    public APIModel Put { get; set; }
    [JsonPropertyName("patch")]
    public APIModel Patch { get; set; }
    [JsonPropertyName("delete")]
    public APIModel Delete { get; set; }

    private string? cacheFile = "api_cache.json";

    public APICallCache()
    {
        Get = new APIModel("", HTTPAction.GET, "");
        Post = new APIModel("", HTTPAction.POST, "");
        Put = new APIModel("", HTTPAction.PUT, "");
        Patch = new APIModel("", HTTPAction.PATCH, "");
        Delete = new APIModel("", HTTPAction.DELETE, "");
    }


    public APICallCache(string file)
    {
        Get = new APIModel("", HTTPAction.GET, "");
        Post = new APIModel("", HTTPAction.POST, "");
        Put = new APIModel("", HTTPAction.PUT, "");
        Patch = new APIModel("", HTTPAction.PATCH, "");
        Delete = new APIModel("", HTTPAction.DELETE, "");

        if (string.IsNullOrEmpty(file))
        {
            return;
        }

        try
        {
            

            cacheFile = file;
            if (File.Exists(file))
            {
                string json = File.ReadAllText(file);

                var cache = JsonSerializer.Deserialize<APICallCache>(json);

                if (cache != null)
                {
                    Get = cache.Get;
                    Post = cache.Post;
                    Put = cache.Put;
                    Patch = cache.Patch;
                    Delete = cache.Delete;
                }

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

        }
    }
    public void AddAPI( APIModel api)
    {
        switch (api.Method)
        {
            case HTTPAction.GET:
                Get = api;
                break;
            case HTTPAction.POST:
                Post = api;
                break;
            case HTTPAction.PUT:
                Put = api;
                break;
            case HTTPAction.PATCH:
                Patch = api;
                break;
            case HTTPAction.DELETE:
                Delete = api;
                break;
        }

        Save();
    }

    public void Save()
    {

        if (string.IsNullOrEmpty(cacheFile))
        {
            return;
        }

        //recreate the cache file
        if (File.Exists(cacheFile))
        {
            File.Delete(cacheFile);
        }

        string json = JsonSerializer.Serialize(this);
        File.WriteAllText(cacheFile, json);
    }

    public void Clear()
    {
        Get = new APIModel("", HTTPAction.GET, "");
        Post = new APIModel("", HTTPAction.POST, "");
        Put = new APIModel("", HTTPAction.PUT, "");
        Patch = new APIModel("", HTTPAction.PATCH, "");
        Delete = new APIModel("", HTTPAction.DELETE, "");
        Save();
    }

    public void UpdateCache(HTTPAction method, APIModel api)
    {
        switch (method)
        {
            case HTTPAction.GET:
                Get = api;
                break;
            case HTTPAction.POST:
                Post = api;
                break;
            case HTTPAction.PUT:
                Put = api;
                break;
            case HTTPAction.PATCH:
                Patch = api;
                break;
            case HTTPAction.DELETE:
                Delete = api;
                break;
        }
        Save();
    }

    public APIModel GetAPI(HTTPAction method)
    {
        switch (method)
        {
            case HTTPAction.GET:
                return Get;
            case HTTPAction.POST:
                return Post;
            case HTTPAction.PUT:
                return Put;
            case HTTPAction.PATCH:
                return Patch;
            case HTTPAction.DELETE:
                return Delete;
            default:
                return new APIModel("", HTTPAction.GET, "");
        }
    }
}



namespace PostmanCloneLibrary
{
    public interface IAPIAccess
    {
        Task<Tuple<bool, string>> CallAPI(string url, HTTPAction action, string content, bool formatOutput = true);
        Task<Tuple<bool, string>> CallAPI(string url, HTTPAction action, StringContent content, bool formatOutput = true);
    }
}
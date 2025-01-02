
namespace PostmanCloneLibrary
{
    public interface IAPIAccess
    {
        Task<Tuple<bool, string>> CallAPI(string url, HTTPAction action, string body, bool formatOutput = true);
    }
}
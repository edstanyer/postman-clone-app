

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Linq;

namespace PostmanCloneLibrary
{
    public static class ValidationHelper
    {

        public static bool IsValidMethod(HTTPAction method)
        {
            return method == HTTPAction.GET || method== HTTPAction.POST || method == HTTPAction.PUT || method == HTTPAction.PATCH || method== HTTPAction.DELETE;
        }

        public static bool IsValidMethod(string method)
        {
            //convert string to HTTP Action

            if (!Enum.TryParse(method, out HTTPAction action))
            {
                return false;
            }

            return IsValidMethod(action);
        }

        public static bool IsValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return false;
            }
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult))
            {
                return false;
            }
            return uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps;
        }

        public static bool IsValidJson(string json)
        {
            try
            {
                JToken.Parse(json);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }

        public static bool IsValidXml(string xml)
        {
            try
            {
                XDocument.Parse(xml);
                return true;
            }
            catch (XmlException)
            {
                return false;
            }
        }

        public static ResponseType GetResponseType(string response)
        {
            if (IsValidJson(response))
            {
                return ResponseType.JSON;
            }
            if (IsValidXml(response))
            {
                return ResponseType.XML;
            }
            return ResponseType.TEXT;
        }


        
    }


}

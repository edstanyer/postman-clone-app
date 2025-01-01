using static PostmanCloneLibrary.ValidationHelper;


using System.Text.Json;
using System;

namespace PostmanCloneLibrary
{

    public static class Formatter
    {

        public static string  FormatResponse(string response)
        { 

            string output = response;

            ResponseType typ = GetResponseType(response);

            switch (typ)
            {
                case ResponseType.JSON:
                    output = FormatJson(response);
                    break;
                case ResponseType.XML:
                    output = FormatXml(response);
                    break;
            }

            return output;
        }


        public static string FormatJson(string json)
        {
            try
            {
                var jsonElement = JsonSerializer.Deserialize<JsonElement>(json);
                return  JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions { WriteIndented = true });
            }
            catch
            {
                return json;
            }
        }
        public static string FormatXml(string xml)
        {
            try
            {
                var xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.LoadXml(xml);
                var stringWriter = new System.IO.StringWriter();
                var xmlTextWriter = new System.Xml.XmlTextWriter(stringWriter) { Formatting = System.Xml.Formatting.Indented };
                xmlDoc.WriteTo(xmlTextWriter);
                return  stringWriter.ToString();
            }
            catch
            {
                return xml;
            }
        }
    }
}

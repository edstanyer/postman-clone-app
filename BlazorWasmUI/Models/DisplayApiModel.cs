using BlazorBootstrap;
using PostmanCloneLibrary;
using PostmanCloneLibrary.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace BlazorWasmUI.Models
{
    public class DisplayApiModel : IAPIModel
    {
        [Display(Name ="Body Content")]
        public string Content { get; set; } = "";

        [Required]
        [Display(Name = "Http Action Type")]
        public HTTPAction Method { get; set; }
        [Required]
        [Url]
        [Display(Name = "API Url")]
        public string? Url { get; set; }

        public DisplayApiModel()
        {
            Content = string.Empty;
            Method = HTTPAction.GET;
            Url = string.Empty;
        }

        public DisplayApiModel(string url, HTTPAction method, string content)
        {
            Url = url;
            Method = method;
            Content = content;
        }
    }
}

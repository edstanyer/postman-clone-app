namespace PostmanCloneLibrary.Models
{
    public interface IAPIModel
    {
        string Content { get; set; }
        HTTPAction Method { get; set; }
        string? Url { get; set; }
    }
}
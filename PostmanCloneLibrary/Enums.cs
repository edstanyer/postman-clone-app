namespace PostmanCloneLibrary;

public enum ResponseType
{
    JSON,
    XML,
    TEXT
}

public enum HTTPAction
{
    GET,
    POST,
    PUT,
    PATCH,
    DELETE
}

public static class EnumExtensions
{
    public static T GetValueFromString<T>(this string value) where T : Enum
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }
}

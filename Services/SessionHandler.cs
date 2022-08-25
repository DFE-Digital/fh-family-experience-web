namespace fh_family_experience_web.Services;

using Newtonsoft.Json;

public static class SessionHandler
{
    public static void Put<T>(this ISession session, string key, T value) where T : class
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public static T? GetOrDefault<T>(this ISession session, string key) where T : class
    {
        if (session.Keys.Any(k => k == key))
        {
            var stringValue = session.GetString(key);
            return string.IsNullOrEmpty(stringValue) ? null : JsonConvert.DeserializeObject<T>(stringValue);
        }

        return null;
    }
}

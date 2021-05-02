using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace ShoppingCart.Infrastructure
{
    public static class SessionExtension
    {
        public static void SetJSON(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetJSON<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData != null ? JsonSerializer.Deserialize<T>(sessionData) : default(T);
        }
    }
}
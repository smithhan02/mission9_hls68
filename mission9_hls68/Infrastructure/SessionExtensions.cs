using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace mission9_hls68.Infrastructure
{
    // All of this just allows us to store an item other than a int, string, or byte 
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value )
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetJson<T> (this ISession session, string key )
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default ( T ) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}

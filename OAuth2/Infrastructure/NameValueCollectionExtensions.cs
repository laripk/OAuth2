using System.Collections.Specialized;
using OAuth2.Client;

namespace OAuth2.Infrastructure
{
    public static class NameValueCollectionExtensions
    {
        public static string GetOrThrowMissingValue(this NameValueCollection collection, string key)
        {
            var value = collection[key];
            if (value.IsEmpty())
            {
                throw new MissingValueException(key);
            }
            return value;
        }
    }
}
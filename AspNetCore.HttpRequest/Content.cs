using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AspNetCore.HttpRequest
{
    public class JsonContent : StringContent
    {
        public JsonContent(object value)
            : base(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json")
        {
        }

        public JsonContent(object value, string mediaType)
            : base(JsonConvert.SerializeObject(value), Encoding.UTF8, mediaType)
        {
        }
    }

    public class PatchContent : StringContent
    {
        public PatchContent(object value)
            : base(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json-patch+json")
        {
        }
    }
    public class Converter
    {
        public static T ConvertObjectToType<T>(object obj)
        {
            var type = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
            return type;
        }
    }
}

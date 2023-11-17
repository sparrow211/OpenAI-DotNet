using OpenAI.Extensions;
using System.Text.Json.Serialization;

namespace OpenAI.Chat
{
    public sealed class ImageUrl
    {
        [JsonConstructor]
        public ImageUrl()
        {
        }

        [JsonConstructor]
        public ImageUrl(string url)
        {
            Url = url;
            Detail = Detail.Auto;
        }

        [JsonConstructor]
        public ImageUrl(string url, Detail detail)
        {
            Url = url;
            Detail = detail;
        }

        [JsonInclude]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url { get; set; }

        [JsonInclude]
        [JsonPropertyName("detail")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonConverter(typeof(JsonStringEnumConverter<Detail>))]
        public Detail Detail { get; set; }
    }
}
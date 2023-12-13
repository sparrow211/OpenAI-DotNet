using OpenAI.Extensions;
using System.Text.Json.Serialization;

namespace OpenAI
{
    public sealed class ImageUrl
    {
        [JsonConstructor]
        public ImageUrl()
        {
        }

        public ImageUrl(string url)
        {
            Url = url;
            Detail = ImageDetail.Auto;
        }

        public ImageUrl(string url, ImageDetail detail = ImageDetail.Auto)
        {
            Url = url;
            Detail = detail;
        }

        [JsonInclude]
        [JsonPropertyName("detail")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ImageDetail Detail { get; set; }

        [JsonInclude]
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url { get; set; }
    }
}
using System.Text.Json.Serialization;
using OpenAI.Extensions;

namespace OpenAI.Chat
{
    public sealed class Content
    {
        public Content()
        { }

        public Content(ContentType type, string input, Detail detail = Detail.Auto)
        {
            Type = type;

            switch (Type)
            {
                case ContentType.Text:
                    Text = input;
                    break;

                case ContentType.ImageUrl:
                    ImageUrl = new ImageUrl(input, detail);
                    break;
            }
        }

        [JsonInclude]
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter<ContentType>))]
        public ContentType Type { get; set; }

        [JsonInclude]
        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Text { get; set; }

        [JsonInclude]
        [JsonPropertyName("image_url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ImageUrl ImageUrl { get; set; }
    }
}
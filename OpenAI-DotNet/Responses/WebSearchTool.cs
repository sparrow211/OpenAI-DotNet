// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAI.Responses
{
    /// <summary>
    /// This tool searches the web for relevant results to use in a response.
    /// </summary>
    public sealed class WebSearchTool : ITool
    {
        public WebSearchTool()
        { }

        public WebSearchTool(
             SearchContextSize searchContextSize = 0,
             UserLocation userLocation = null,
             WebSearchFilters filters = null)
        {
            SearchContextSize = searchContextSize;
            UserLocation = userLocation;
            Filters = filters;
        }

        [JsonInclude]
        [JsonPropertyName("filters")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WebSearchFilters Filters { get; private set; }

        /// <summary>
        /// High level guidance for the amount of context window space to use for the search. One of low, medium, or high. medium is the default.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("search_context_size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SearchContextSize SearchContextSize { get; private set; }

        [JsonInclude]
        [JsonPropertyName("type")]
        public string Type { get; private set; } = "web_search";

        /// <summary>
        /// The user's location.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("user_location")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UserLocation UserLocation { get; private set; }

        public static implicit operator Tool(WebSearchTool webSearchPreviewTool) => new(webSearchPreviewTool as ITool);
    }
}

public sealed class WebSearchFilters
{
    public WebSearchFilters()
    { }

    public WebSearchFilters(IEnumerable<string> allowedDomains)
    {
        AllowedDomains = allowedDomains != null ? [.. allowedDomains] : null;
    }

    [JsonInclude]
    [JsonPropertyName("allowed_domains")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string> AllowedDomains { get; private set; }
}
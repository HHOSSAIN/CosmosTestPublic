
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace CosmosTestPublic.Models
{
    public class GlobalSettings
    {
        public string? Id { get; set; }

        //[JsonProperty(PropertyName = "templates")]
        public List<Template>? templates;
    }
}

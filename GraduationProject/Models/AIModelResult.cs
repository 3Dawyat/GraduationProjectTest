using Newtonsoft.Json;

namespace GraduationProject.API.Models
{
    public class AIModelResult
    {
        [JsonProperty("class_name")]
        public string? ClassName { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace GraduationProject.API.Data.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Key { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}

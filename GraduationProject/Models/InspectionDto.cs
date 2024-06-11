namespace GraduationProject.API.Models
{
    public record InspectionDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? ImageUrl { get; set; }
        public string? TreatmentTitle { get; set; }
        public string? TreatmentKey { get; set; }
        public string? TreatmentContent { get; set; }
    }
}

namespace GraduationProject.API.Data.Models
{
    public class Inspection
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public ApplicationUser? User { get; set; } 
        public string? UserId { get; set; }    
        public string? FileUrl { get; set; }    
        
        public Treatment? Treatment { get; set; } 
        public int TreatmentId { get; set; }

    }

}

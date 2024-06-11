using Microsoft.AspNetCore.Identity;

namespace GraduationProject.API.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = null!;
    }

}

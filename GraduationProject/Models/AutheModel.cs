﻿namespace GraduationProject.API.Models
{
    public class AutheModel
    {
        public string? Massage { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Token { get; set; }
    }
}

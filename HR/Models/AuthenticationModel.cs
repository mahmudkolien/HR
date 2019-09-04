using System;
using System.ComponentModel.DataAnnotations;

namespace HR.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    
    public class AuthenticateUserModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ImageFile { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
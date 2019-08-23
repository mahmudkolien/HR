using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace HR.Models
{
    public class SaveUserModel
    {
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        //public string ImageFile { get; set; }
        [Required]
        public Guid UserRoleId { get; set; }
        public IFormFile InputFile { get; set; }
    }
}
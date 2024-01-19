using System;
using System.ComponentModel.DataAnnotations;

namespace RoleBasedAuthentication.Models{
    public class User{
        [Required]
        public string? Username{get;set;}
        [Required(ErrorMessage ="Please enter password")]
        public string? Password{get;set;}
    
    }
}
﻿using System.ComponentModel.DataAnnotations;

namespace EShop.API.DTOS
{
    public class LoginDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}

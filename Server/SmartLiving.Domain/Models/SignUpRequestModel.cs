﻿using System.ComponentModel.DataAnnotations;

namespace SmartLiving.Domain.Models
{
    public class SignUpRequestModel
    {
        [Required] public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }
    }
}
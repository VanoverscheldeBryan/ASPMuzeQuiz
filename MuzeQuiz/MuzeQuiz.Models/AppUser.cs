using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MuzeQuiz.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(50,MinimumLength = 2 , ErrorMessage = "First Name can only be 2 to 50 characters long")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name can only be 2 to 50 characters long")]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateRegistered { get; set; } = DateTime.Now;

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

    }
}

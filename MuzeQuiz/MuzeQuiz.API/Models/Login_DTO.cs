using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuzeQuiz.API.Models
{
    public class Login_DTO
    {

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name can only be 2 to 50 characters long")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Last can only be 2 to 50 characters long")]
        public string Password { get; set; }

    }
}

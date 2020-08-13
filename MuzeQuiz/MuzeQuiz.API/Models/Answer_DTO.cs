using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuzeQuiz.API.Models
{
    public class Answer_DTO
    {

        [StringLength(50, ErrorMessage = "Answers are limited to 50 characters")]
        public string Answer_Text { get; set; }

        [Range(0, 1)]
        public String YesNo { get; set; }

        [Required, Range(0, 1)]
        public Boolean IsCorrect { get; set; }

    }
}

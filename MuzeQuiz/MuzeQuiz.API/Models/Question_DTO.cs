using MuzeQuiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuzeQuiz.API.Models
{
    public class Question_DTO
    {

        [Required, StringLength(250, MinimumLength = 5, ErrorMessage = "Question Lenght must be between 5 and 250 characters.")]
        public string QuestionSelf { get; set; }

        [Required]
        public String Type { get; set; }

        [StringLength(100, MinimumLength = 10)]
        public string ImgUrl { get; set; }


        public List<Answer_DTO> Answers { get; set; }

    }
}

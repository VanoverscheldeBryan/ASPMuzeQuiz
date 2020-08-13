using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MuzeQuiz.Models
{
    public class Answer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50, ErrorMessage = "Answers are limited to 50 characters")]
        public string Answer_Text { get; set; }

        [Range(0,1)]
        public Yesno YesNo { get; set; }

        [Required, Range(0,1)]
        public Boolean IsCorrect { get; set; }

        public enum Yesno
        {
            no = 0,
            yes = 1
        }

        // for keys
        public Guid QuestionId { get; set; }

        // nav props

        public virtual Question Question { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MuzeQuiz.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required,StringLength(250, MinimumLength = 5, ErrorMessage = "Question Lenght must be between 5 and 250 characters.")]
        public string QuestionSelf { get; set; }

        [Required]
        public QType Type { get; set; }

        [StringLength(100, MinimumLength =10)]
        public string ImgUrl { get; set; }

        public enum QType
        {
            Text = 0,
            Yesno = 1
        }

        // For Keys

        public Guid QuizId { get; set; }

        // nav props

        public virtual Quiz Quiz { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MuzeQuiz.Models
{
    public class Rating
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public intRating ratingNumber { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid QuizId { get; set; }

        public enum intRating
        {
            very_bad = 0,
            bad = 1,
            alright = 2,
            good = 3,
            very_good = 4,

        }

        public virtual AppUser appuser { get; set; }

        public virtual Quiz quiz { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MuzeQuiz.Models
{
    public class Quiz
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(100, MinimumLength = 3, ErrorMessage = " Name must be between 3 and 100 charachter")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Descreption is limited to 250 charachter")]
        public string Description { get; set; }

        [Required]
        public Difficulty Diff { get; set; }

        public enum Difficulty
        {
            easy = 0,
            medium = 1,
            hard = 2,
        }

        // Foreign Keys

        public string AppUserId { get; set; }

        // Nav props

        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MuzeQuiz.Models
{
    public class Scores
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        // for keys

        public string AppUserId { get; set; }

        public Guid QuizId { get; set; }

        // nav prop

        public virtual AppUser AppUser { get; set; }

        public virtual Quiz Quiz { get; set; }

    }
}

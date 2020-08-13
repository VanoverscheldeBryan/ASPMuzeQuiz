using MuzeQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuzeQuiz.Web.ViewModels
{
    public class QuizScore
    {

        public Scores score { get; set; }

        public Quiz quiz { get; set; }

        public Rating rating { get; set; }
    }
}

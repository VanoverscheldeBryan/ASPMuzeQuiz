using MuzeQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuzeQuiz.Web.ViewModels
{
    public class fullQuiz
    {

        public string quizName { get; set; }

        public Guid quizId { get; set; }

        public int QuestionIndex { get; set; } = 0;

        public Question quizQuestion { get; set; }

        public List<Answer> answers { get; set; }


    }
}

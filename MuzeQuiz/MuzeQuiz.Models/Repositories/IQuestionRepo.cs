using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuzeQuiz.Models.Repositories
{
    public interface IQuestionRepo
    {
        Task<IEnumerable<Question>> GetQuestionsQuiz(Guid quizid);

        Task<Question> AddQuestionToQuiz(Question qstn);

        Task<Question> GetQuestionByIdAsync(Guid id);

        Task DeleteQuestionAsync(Guid id);
    }
}

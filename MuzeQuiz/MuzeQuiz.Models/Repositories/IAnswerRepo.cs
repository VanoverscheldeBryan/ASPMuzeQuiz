using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuzeQuiz.Models.Repositories
{
    public interface IAnswerRepo
    {
        Task<IEnumerable<Answer>> GetAnswersForQuestion(Guid questionid);

        Task<Answer> AddAnswerToQuestion(Answer answer);

        Task<Answer> GetAnswerByIdAsync(Guid id);

        Task DeleteAnswerAsync(Guid id);

    }
}

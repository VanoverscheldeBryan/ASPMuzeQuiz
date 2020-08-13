using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuzeQuiz.Models.Repositories
{
    public interface IQuizRepo
    {
        // read

        Task<IEnumerable<Quiz>> GetAllQuizesAsync();

        Task<IEnumerable<Quiz>> GetQuizzesUser(string appuserId);

        Task<Quiz> GetQuizById(Guid id);

        Task<Quiz> GetQuizByNameAsync(string name);

        // create
        Task<Quiz> AddQuizAsync(Quiz quiz);

        //put
        Task UpdateQuiz(Quiz quiz);

        //delete
        Task DeleteQuizAsync(Guid id);


    }
}

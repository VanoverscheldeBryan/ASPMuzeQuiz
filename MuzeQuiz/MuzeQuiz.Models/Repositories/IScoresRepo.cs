using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuzeQuiz.Models.Repositories
{
    public interface IScoresRepo
    {
        Task<IEnumerable<Scores>> GetAllScoresAsync();

        Task<Scores> AddScoreAsync(Scores score);
    }
}

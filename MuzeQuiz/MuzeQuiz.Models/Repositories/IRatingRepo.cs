using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuzeQuiz.Models.Repositories
{
    public interface IRatingRepo
    {

        Task<Rating> AddRatingAsync(Rating rate);

        Task<IEnumerable<Rating>> GetRatingsAsync();

    }
}

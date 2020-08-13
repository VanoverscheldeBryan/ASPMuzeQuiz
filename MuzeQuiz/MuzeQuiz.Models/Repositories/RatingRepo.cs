using MuzeQuiz.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuzeQuiz.Models.Repositories
{
    public class RatingRepo : IRatingRepo
    {
        private readonly DevDbContext _context;

        public RatingRepo(DevDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Rating>> GetRatingsAsync()
        {
            try
            {
                var result = await _context.Ratings.ToListAsync();

                return result;

            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<Rating> AddRatingAsync(Rating rating)
        {
            try
            {
                var result = await _context.Ratings.AddAsync(rating);
                await _context.SaveChangesAsync();

                return rating;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

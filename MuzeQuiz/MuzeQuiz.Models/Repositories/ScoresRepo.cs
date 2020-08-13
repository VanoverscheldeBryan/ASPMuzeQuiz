using MuzeQuiz.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzeQuiz.Models.Repositories
{
    public class ScoresRepo : IScoresRepo
    {
        private readonly DevDbContext _context;

        public ScoresRepo(DevDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Scores>> GetAllScoresAsync()
        {
            try
            {
                var result = await _context.Scores.ToListAsync();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Scores>> GetScoreUsers(string userid)
        {
            try
            {
                var result = await _context.Scores.Where(s => s.AppUserId == userid).ToListAsync();

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Scores> AddScoreAsync(Scores score)
        {
            try
            {
                var reslust = await _context.Scores.AddAsync(score);
                await _context.SaveChangesAsync();

                return score;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

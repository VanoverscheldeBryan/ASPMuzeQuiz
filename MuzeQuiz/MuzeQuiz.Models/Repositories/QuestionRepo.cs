using MuzeQuiz.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MuzeQuiz.Models.Repositories
{
    public class QuestionRepo : IQuestionRepo
    {

        private readonly DevDbContext _context;

        public QuestionRepo(DevDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Question>> GetQuestionsQuiz(Guid quizid)
        {
            try
            {
                var result = await _context.Questions.Where(q => q.QuizId == quizid).Include(e => e.Answers).ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }

            
        }

        public async Task<Question> AddQuestionToQuiz(Question qstn)
        {
            try
            {
                var result = await _context.Questions.AddAsync(qstn);
                await _context.SaveChangesAsync();

                return qstn;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Question> GetQuestionByIdAsync(Guid id)
        {

            try
            {
                var result = await _context.Questions.SingleOrDefaultAsync(e => e.Id == id);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteQuestionAsync(Guid id)
        {

            try
            {
                var result = await _context.Questions.Where(q => q.Id == id).Include(e => e.Answers).ToListAsync();

                _context.Questions.RemoveRange(result);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        
        }
    }
}

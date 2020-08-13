using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MuzeQuiz.Web.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MuzeQuiz.Models.Repositories
{
    public class QuizRepo : IQuizRepo
    {
        private readonly DevDbContext _context;

        public QuizRepo(DevDbContext context)
        {
            this._context = context;
        }

        // read

        public async Task<IEnumerable<Quiz>> GetAllQuizesAsync()
        {
            try
            {
                var result = await _context.Quizzes.Include(q => q.Questions).ThenInclude(q => q.Answers).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
            
        }

        public async Task<IEnumerable<Quiz>> GetQuizzesUser(string appuserId)
        {
            try
            {
                var result = await _context.Quizzes.Where(q => q.AppUserId == appuserId).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
        }

        public async Task<Quiz> GetQuizById(Guid id)
        {
            try
            {
                var result = await _context.Quizzes.SingleOrDefaultAsync(q => q.Id == id);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Quiz> GetQuizByNameAsync(string name)
        {
            try
            {
                var result = await _context.Quizzes.Include(e => e.Questions).ThenInclude(e => e.Answers).SingleOrDefaultAsync(q => q.Name == name);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //create

        public async Task<Quiz> AddQuizAsync(Quiz quiz)
        {
            try
            {
                var result = await _context.Quizzes.AddAsync(quiz);
                await _context.SaveChangesAsync();
                return quiz;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }

        }

        // update
        public async Task UpdateQuiz(Quiz quiz)
        {
            try
            {
                var result = await _context.Quizzes.FirstOrDefaultAsync(e => e.Id == quiz.Id);
                result.Name = quiz.Name;
                result.Description = quiz.Description;
                result.Diff = quiz.Diff;

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }



        //delete 

        public async Task DeleteQuizAsync(Guid id)
        {
            try
            {
                var result = await _context.Quizzes.Where(q => q.Id == id).Include(q => q.Questions).ThenInclude(q => q.Answers).ToListAsync();

                _context.Quizzes.RemoveRange(result);
                

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
            }
            return;
        }
    }
}

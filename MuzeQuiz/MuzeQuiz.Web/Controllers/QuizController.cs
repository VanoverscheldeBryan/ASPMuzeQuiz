using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzeQuiz.Models;
using MuzeQuiz.Models.Repositories;
using MuzeQuiz.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JAQ_BackendDev.Web.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IQuizRepo _quizRepo;
        private readonly IQuestionRepo _questionRepo;
        private readonly IAnswerRepo _answerRepo;
        private readonly IRatingRepo _ratingRepo;

        public QuizController(UserManager<AppUser> userManager, IQuizRepo quizRepository, IQuestionRepo questionRepo, IAnswerRepo answerRepo, IRatingRepo ratingRepo)
        {
            this._userManager = userManager;
            this._quizRepo = quizRepository;
            this._questionRepo = questionRepo;
            this._answerRepo = answerRepo;
            this._ratingRepo = ratingRepo;
        }

        // GET: Quiz
        public async Task<ActionResult> Quizzes()
        {
            var result = await _quizRepo.GetAllQuizesAsync();

            return View(result);
        }

        public async Task<ActionResult> MyQuizzes()
        {
            string usrid = _userManager.GetUserId(User);

            var result = await _quizRepo.GetQuizzesUser(usrid);

            return View(result);
        }

        public async Task<ActionResult> Questions(Guid quizid)
        {
            var result = await _questionRepo.GetQuestionsQuiz(quizid);
                try
                {
                    var qz = await _quizRepo.GetQuizById(quizid);
                    ViewBag.QuizName = qz.Name;
                    ViewBag.QuizId = qz.Id;

                    return View(result);
                }
                catch (Exception)
                {

                    throw;
                }
        }

        public async Task<ActionResult> Answers(Guid id)
        {
            var result = await _answerRepo.GetAnswersForQuestion(id);
                try
                {
                    var question = await _questionRepo.GetQuestionByIdAsync(id);

                    ViewBag.QstName = question.QuestionSelf;
                    ViewBag.QstId = id;

                    return View(result);
                }
                catch (Exception)
                {

                    throw;
                }
        }

        public async Task<ActionResult> PlayQuiz(Guid quizId)
        {
            Quiz qz = await _quizRepo.GetQuizById(quizId);

            if (qz == null)
            {
                return StatusCode(404);
            }

            else
            {
                try
                {

                    fullQuiz fq = new fullQuiz() { quizName = qz.Name, quizId = qz.Id };

                    var qstnList = await _questionRepo.GetQuestionsQuiz(fq.quizId);
                    var qstnSelf = qstnList.ToList()[fq.QuestionIndex];

                    var ansListIe = await _answerRepo.GetAnswersForQuestion(qstnSelf.Id);
                    var ansList = ansListIe.ToList();

                    fq.quizQuestion = qstnSelf;
                    fq.answers = ansList;

                    ViewBag.score = 0;

                    return View("PlayQuiz", fq);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        public async Task<ActionResult> NextQuestion(string quizName, Guid quizId,int qstnIndex,DateTime date, bool correct, int score)
        {
            try
            {
                var qstnList = await _questionRepo.GetQuestionsQuiz(quizId);

                if (correct)
                {
                    TimeSpan timeDiff = DateTime.Now.Subtract(date);
                    if (timeDiff.TotalSeconds > 30 && timeDiff.TotalSeconds < 0)
                    {
                    }
                    else
                    {

                        if (score >= (qstnList.Count() * 300))
                        {
                            score = 0;
                        }
                        else
                        {
                            int stp1 = 30 - Convert.ToInt32(timeDiff.TotalSeconds);
                            score = score + (stp1 * 10);
                        }
                    }
                }
                else
                {
                }

                fullQuiz fq = new fullQuiz() { quizName = quizName, quizId = quizId, QuestionIndex = qstnIndex };
                fq.QuestionIndex += 1;

                if (fq.QuestionIndex >= qstnList.Count())
                {

                    // add score to database
                    Scores newscore = new Scores()
                    {
                        AppUserId = _userManager.GetUserId(User),
                        QuizId = fq.quizId,
                        Date = DateTime.Now
                    };
                    Quiz qz = await _quizRepo.GetQuizById(fq.quizId);

                    QuizScore qzsc = new QuizScore() { score = newscore, quiz = qz };

                    ViewBag.score = score;

                    return View("EndQuiz", qzsc);
                }
                else
                {
                    var qstnSelf = qstnList.ToList()[fq.QuestionIndex];

                    var ansListIe = await _answerRepo.GetAnswersForQuestion(qstnSelf.Id);
                    var ansList = ansListIe.ToList();

                    fq.quizQuestion = qstnSelf;
                    fq.answers = ansList;

                    ViewBag.score = score;

                    return View("PlayQuiz", fq);
                }
            }
            catch (Exception)
            {

                throw;
            }


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRating(IFormCollection collection, QuizScore qz)
        {
            try
            {
                Rating rtSelf = qz.rating;
                rtSelf.UserId = Guid.Parse(_userManager.GetUserId(User));

                var result = await _ratingRepo.AddRatingAsync(rtSelf);

                return View("AccceptRating");
            }
            catch (Exception)
            {

                throw;
            }
        }


        // GET: Quiz/Create
        [Authorize(Roles = "Admin, Creator")]
        public ActionResult CreateQuiz()
        {
            return View();
        }

        // POST: Quiz/Create
        [Authorize(Roles = "Admin, Creator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateQuiz(IFormCollection collection, Quiz quiz)
        {
            try
            {
                // TODO: Add insert logic here
                quiz.AppUserId = _userManager.GetUserId(User);
                var created = await _quizRepo.AddQuizAsync(quiz);
                if (created == null)
                {
                    throw new Exception("Invalid Entry.");
                }
                return RedirectToAction(nameof(MyQuizzes));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin, Creator")]
        public ActionResult CreateQuestion(Guid quizid)
        {
            ViewBag.QuizId = quizid;
            return View();
        }

        // POST: Quiz/Create
        [Authorize(Roles = "Admin, Creator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateQuestion(IFormCollection collection, Question question)
        {
            try
            {
                var created = await _questionRepo.AddQuestionToQuiz(question);
                if (created == null)
                {
                    throw new Exception("Invalid Entry.");
                }
                return RedirectToAction("Questions", "Quiz", new { quizid = created.QuizId });
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin, Creator")]
        public async Task<ActionResult> CreateAnswer(Guid questionid)
        {
            ViewBag.QstId = questionid;
            return View();
        }


        [Authorize(Roles = "Admin, Creator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAnswer(IFormCollection collection, Answer ans)
        {
            try
            {
                // TODO: Add insert logic here
                var created = await _answerRepo.AddAnswerToQuestion(ans);
                if (created == null)
                {
                    throw new Exception("Invalid Entry.");
                }
                return RedirectToAction("Answers", "Quiz", new { id = created.QuestionId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Quiz/Edit/5
        [Authorize(Roles = "Admin, Creator")]
        public async Task<ActionResult> EditQuiz(Guid id)
        {
            var result = await _quizRepo.GetQuizById(id);

            return View(result);
        }

        // POST: Quiz/Edit/5
        [Authorize(Roles = "Admin, Creator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditQuiz(IFormCollection collection, Quiz quiz)
        {
            try
            {
                await _quizRepo.UpdateQuiz(quiz);

                return RedirectToAction("MyQuizzes");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quiz/Delete/5
        [Authorize(Roles = "Admin, Creator")]
        public async Task<ActionResult> DeleteQuiz(Guid id)
        {
            if (id == null)
                return BadRequest();

            var quiz = await _quizRepo.GetQuizById(id);

            return View(quiz);
        }

        // POST: Quiz/Delete/5
        [Authorize(Roles = "Admin, Creator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteQuiz(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                await _quizRepo.DeleteQuizAsync(id);

                return RedirectToAction(nameof(MyQuizzes));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin, Creator")]
        public async Task<ActionResult> DeleteQuestion(Guid id)
        {
            if (id == null)
                return BadRequest();

            var question = await _questionRepo.GetQuestionByIdAsync(id);

            return View(question);
        }

        // POST: Quiz/Delete/5
        [Authorize(Roles = "Admin, Creator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteQuestion(Guid id, IFormCollection collection)
        {
            try
            {
                var qst = await _questionRepo.GetQuestionByIdAsync(id);
                // TODO: Add delete logic here
                await _questionRepo.DeleteQuestionAsync(id);

                return RedirectToAction("Questions", "Quiz", new { quizid = qst.QuizId });
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin, Creator")]
        public async Task<ActionResult> DeleteAnswer(Guid id)
        {
            if (id == null)
                return BadRequest();

            var ans = await _answerRepo.GetAnswerByIdAsync(id);

            return View(ans);

        }

        [Authorize(Roles = "Admin, Creator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAnswer(Guid id, IFormCollection collection)
        {
            try
            {
                var ans = await _answerRepo.GetAnswerByIdAsync(id);
                // TODO: Add delete logic here
                await _answerRepo.DeleteAnswerAsync(id);

                return RedirectToAction("Answers", "Quiz", new { id = ans.QuestionId });
            }
            catch
            {
                return View();
            }
        }

    }
}
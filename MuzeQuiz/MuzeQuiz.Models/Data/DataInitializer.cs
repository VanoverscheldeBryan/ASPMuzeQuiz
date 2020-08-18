using MuzeQuiz.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzeQuiz.Models.Data
{
    public class DataInitializer : IDataInitializer
    {

        private readonly IQuizRepo _quizRepo;
        private readonly IQuestionRepo _questionRepo;
        private readonly IAnswerRepo _answerRepo;
        private readonly UserManager<AppUser> _userMgr;

        public DataInitializer(IQuizRepo quizrepo, IQuestionRepo questionRepo, IAnswerRepo answerRepo, UserManager<AppUser> userMgr)
        {
            this._quizRepo = quizrepo;
            this._questionRepo = questionRepo;
            this._answerRepo = answerRepo;

            this._userMgr = userMgr;
        }

        public async Task InitQuizzes()
        {
            if (await _userMgr.FindByEmailAsync("Docent@MCT.be") != null)
            {
                var usr = await _userMgr.FindByEmailAsync("Docent@MCT.be");
                if (await _quizRepo.GetQuizByNameAsync("Music") == null)
                {
                    var quiz1 = new Quiz()
                    {
                        Name = "Music",
                        Description = "Quiz About Music Facts",
                        Diff = 0,
                        AppUserId = usr.Id
                    };

                    Quiz quizMade = await _quizRepo.AddQuizAsync(quiz1);

                    List<String> qstList1 = new List<string> {
                        "Who is called the king of POP ?",
                        "Who made the most popular christmass song ?",
                        "Who is called GOAT in the rap industry ?",
                        "Who made the most cringy song that made his fame rise ?",
                        "Which artist has alot of numbers on his body ?",
                        "Which dutch rapper quit his show because someone throwed a beer at him ?",
                        "Which DJ is number one in 2020 ?",
                        "With what song did Martin Garrix blow up ?",
                        "What is Hawkeys' first song release ?",
                        "How old is Hawkeys ?"};

                    List<List<string>> ansList = new List<List<string>> {
                        new List<string>{"Drake","Lady Gaga","Nirvana", "Michael Jackson", "3"},
                        new List<string>{"Mariah Carey","Britney Spears","Eminem","The Beatles", "0"},
                        new List<string>{"2pac","Eminem","Dr. Dre","MGK", "1"},
                        new List<string>{"Ed Sheeran","Daddy Yankee","Biggie","Justin Bieber", "3"},
                        new List<string>{"6IX9INE","Lil Skies","Lil Uzi","Travis scott", "0"},
                        new List<string>{"Boef","Moeman","KA","Lil Kleine", "3"},
                        new List<string>{"Fisher","Oliver Heldens","Martin Garrix","Tiesto", "2"},
                        new List<string>{"High on Life","Virus","Poison","Animals", "3"},
                        new List<string>{"Roses","Rasta","Bounce","Ya head", "0"},
                        new List<string>{"25","28","20","18", "2"}
                    };

                    for (int i = 0; i < qstList1.Count; i++)
                    {
                        Question qst = new Question()
                        {
                            QuestionSelf = qstList1[i],
                            QuizId = quizMade.Id,
                            Type = 0,
                        };

                        // create Question
                        var resultqst = await _questionRepo.AddQuestionToQuiz(qst);

                        for (int a = 0; a < 4; a++)
                        {
                            if (a == int.Parse(ansList[i][4]))
                            {
                                Answer ans = new Answer()
                                {
                                    IsCorrect = true,
                                    Answer_Text = ansList[i][a],
                                    QuestionId = qst.Id
                                };
                                var resultans = await _answerRepo.AddAnswerToQuestion(ans);
                            }

                            else
                            {
                                Answer ans = new Answer()
                                {
                                    IsCorrect = false,
                                    Answer_Text = ansList[i][a],
                                    QuestionId = qst.Id

                                };
                                var resultans = await _answerRepo.AddAnswerToQuestion(ans);
                            }

                        }


                    }

                }
            }
        }

    }
}

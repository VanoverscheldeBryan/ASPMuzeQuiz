using MuzeQuiz.Models;
using MuzeQuiz.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuzeQuiz.API.Models
{
    public class Mapper
    {
        private readonly IQuestionRepo questionRepo;

        public Mapper(IQuestionRepo questionRepo )
        {
            this.questionRepo = questionRepo;
        }


        public static Quiz_DTO QuizTo_DTO(Quiz quiz, ref Quiz_DTO quiz_DTO)
        {
            quiz_DTO.Name = quiz.Name;

            quiz_DTO.Description = quiz.Description;

            List<Question_DTO> questionsWithAns = new List<Question_DTO>();

            if (quiz.Diff == Quiz.Difficulty.easy)
            {
                quiz_DTO.Difficulty = "easy";
            }

            else if (quiz.Diff == Quiz.Difficulty.medium)
            {
                quiz_DTO.Difficulty = "medium";
            }

            else if (quiz.Diff == Quiz.Difficulty.hard)
            {
                quiz_DTO.Difficulty = "hard";
            }

            foreach (var qstn in quiz.Questions)
            {

                Question_DTO question_DTO = new Question_DTO();

                question_DTO.QuestionSelf = qstn.QuestionSelf;
                question_DTO.ImgUrl = qstn.ImgUrl;

                if (qstn.Type == Question.QType.Text)
                {
                    question_DTO.Type = "Text";
                }
                else if (qstn.Type == Question.QType.Yesno)
                {
                    question_DTO.Type = "Yesno";
                }

                List<Answer_DTO> anslist = new List<Answer_DTO>();
                foreach (var answer in qstn.Answers)
                {
                    Answer_DTO answer_DTO = new Answer_DTO();

                    answer_DTO.Answer_Text = answer.Answer_Text;
                    answer_DTO.IsCorrect = answer.IsCorrect;

                    if (answer.YesNo == Answer.Yesno.yes)
                    {
                        answer_DTO.YesNo = "yes";
                    }

                    else if (answer.YesNo == Answer.Yesno.no)
                    {
                        answer_DTO.YesNo = "no";
                    }

                    anslist.Add(answer_DTO);

                }

                question_DTO.Answers = anslist;

                questionsWithAns.Add(question_DTO);
            }

            quiz_DTO.questions = questionsWithAns;

            return quiz_DTO;

        }

        public static Question_DTO questionTo_DTO(Question question, ref Question_DTO question_DTO)
        {
            question_DTO.QuestionSelf = question.QuestionSelf;
            question_DTO.ImgUrl = question.ImgUrl;

            if (question.Type == Question.QType.Text)
            {
                question_DTO.Type = "Text";
            }
            else if (question.Type == Question.QType.Yesno)
            {
                question_DTO.Type = "Yesno";
            }

            List<Answer_DTO> anslist = new List<Answer_DTO>();
            foreach (var answer in question.Answers)
            {
                Answer_DTO answer_DTO = new Answer_DTO();

                answer_DTO.Answer_Text = answer.Answer_Text;
                answer_DTO.IsCorrect = answer.IsCorrect;

                if (answer.YesNo == Answer.Yesno.yes)
                {
                    answer_DTO.YesNo = "yes";
                }

                else if (answer.YesNo == Answer.Yesno.no)
                {
                    answer_DTO.YesNo = "no";
                }

                anslist.Add(answer_DTO);

            }

            question_DTO.Answers = anslist;

            return question_DTO;

        }


        public static Answer_DTO answerTo_DTO(Answer answer, ref Answer_DTO answer_DTO)
        {
            answer_DTO.Answer_Text = answer.Answer_Text;
            answer_DTO.IsCorrect = answer.IsCorrect;

            if (answer.YesNo == Answer.Yesno.yes)
            {
                answer_DTO.YesNo = "yes";
            }

            else if (answer.YesNo == Answer.Yesno.no)
            {
                answer_DTO.YesNo = "no";
            }

            return answer_DTO;

        }

    }
}

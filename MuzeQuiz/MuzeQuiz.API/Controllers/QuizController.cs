using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuzeQuiz.API.Models;
using MuzeQuiz.Models;
using MuzeQuiz.Models.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MuzeQuiz.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {

        private const string AuthSchemes = CookieAuthenticationDefaults.AuthenticationScheme + ",Identity.Application";

        private readonly IQuizRepo quizRepo;

        public QuizController(IQuizRepo quizRepo)
        {
            this.quizRepo = quizRepo;
        }

        // GET: api/Quiz
        [Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Admin, Creator")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quiz_DTO>>> GetQuizzes()
        {
            var model = await quizRepo.GetAllQuizesAsync();

            List<Quiz_DTO> model_DTO = new List<Quiz_DTO>();

            foreach (Quiz qz in model)
            {
                Quiz_DTO result = new Quiz_DTO();
                model_DTO.Add(Mapper.QuizTo_DTO(qz, ref result));
            }

            return Ok(model_DTO);
            
        }

        // GET: api/Quiz/5
        [Authorize(AuthenticationSchemes = AuthSchemes, Roles = "Admin, Creator")]
        [HttpGet("{name}")]
        public async Task<ActionResult<Quiz_DTO>> getQuizzesByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("ongeldige naam");
            }

            var quiz = await quizRepo.GetQuizByNameAsync(name);

            if (quiz == null)
            {
                return NotFound("geen quiz gevonden");
            }

            var quiz_DTO = new Quiz_DTO();
            var quiz_DTOResult = Mapper.QuizTo_DTO(quiz, ref quiz_DTO);

            return Ok(quiz_DTOResult);
        }
    }
}

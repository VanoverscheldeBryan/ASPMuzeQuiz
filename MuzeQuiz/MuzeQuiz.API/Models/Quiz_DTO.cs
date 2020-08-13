using MuzeQuiz.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuzeQuiz.API.Models
{
    public class Quiz_DTO
    {
        [Required, StringLength(100, MinimumLength = 3, ErrorMessage = " Name must be between 3 and 100 charachter")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Descreption is limited to 250 charachter")]
        public string Description { get; set; }
        
        public string Difficulty { get; set; }


        [JsonProperty("questions", NullValueHandling = NullValueHandling.Ignore)]
        //nav prop
        public List<Question_DTO> questions { get; set; }

    }
}

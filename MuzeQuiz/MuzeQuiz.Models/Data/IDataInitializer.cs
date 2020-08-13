using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuzeQuiz.Models.Data
{
    public interface IDataInitializer
    {
        Task InitQuizzes();
    }
}

using IQ_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQ_Test.Data
{
    public interface IQuestionRepo
    {
        bool SaveChanges();

        IEnumerable<QuestionModel> GetAllQuestions();
        QuestionModel GetQuestionById(int id);
        void CreateQuestion(QuestionModel ques);
        void UpdateQuestion(QuestionModel ques);
        void DeleteQuestion(QuestionModel ques);
    }
}

using IQ_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQ_Test.Data
{
    public class SqlQuestionRepo : IQuestionRepo
    {
        private readonly QuestionContext _context;

        public SqlQuestionRepo(QuestionContext context)
        {
            _context = context;
        }

        public void CreateQuestion(QuestionModel ques)
        {
           if(ques == null)
            {
                throw new ArgumentNullException(nameof(ques));
            }
            _context.Questions.Add(ques);
        }

        public void DeleteQuestion(QuestionModel ques)
        {
            if (ques == null)
            {
                throw new ArgumentNullException(nameof(ques));
            }
            _context.Questions.Remove(ques);
        }

        //Get all the questions from the SQL database
        public IEnumerable<QuestionModel> GetAllQuestions()
        {
            return _context.Questions.ToList();
        }

        //Get a question by Qid 
        public QuestionModel GetQuestionById(int id)
        {
            return _context.Questions.FirstOrDefault(p => p.Qid == id);
        }

        //Save the Changes
        public bool SaveChanges()
        {
          return (_context.SaveChanges() >= 0);
        }

        public void UpdateQuestion(QuestionModel ques)
        {
            //Nothing
        }
    }
}

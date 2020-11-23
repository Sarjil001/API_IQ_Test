using IQ_Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQ_Test.Data
{
    public class QuestionContext : DbContext
    {
        public QuestionContext(DbContextOptions<QuestionContext> opt) : base(opt)
        {

        }

        //Dbset from the SQL server for table OnileIQtest.dbo.Questions
        public DbSet<QuestionModel> Questions { get; set; }
    }
}

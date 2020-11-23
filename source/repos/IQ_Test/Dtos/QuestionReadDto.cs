using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQ_Test.Dtos
{
    public class QuestionReadDto
    {
            public int Qid { get; set; }

            public string Question { get; set; }

            public string option1 { get; set; }

            public string option2 { get; set; }

            public string option3 { get; set; }

            public string option4 { get; set; }

            public string Correctans { get; set; }

    }
}

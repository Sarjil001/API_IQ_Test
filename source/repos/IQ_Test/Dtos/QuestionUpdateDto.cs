using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IQ_Test.Dtos
{
    public class QuestionUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Question { get; set; }

        [Required]
        public string option1 { get; set; }

        [Required]
        public string option2 { get; set; }

        [Required]
        public string option3 { get; set; }

        [Required]
        public string option4 { get; set; }

        [Required]
        public string Correctans { get; set; }

    }
}

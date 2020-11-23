using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IQ_Test.Models;
using IQ_Test.Data;

namespace IQ_Test.Controllers
{
    public class ExamController : Controller
    {
        private readonly QuestionContext _adb;

        public ExamController(QuestionContext adb)
        {
            _adb = adb;

        }
        public IActionResult Index()
        {
            var results = _adb.Questions.ToList();
            return View(results);
        }
    }
}


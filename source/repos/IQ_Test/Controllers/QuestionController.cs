using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IQ_Test.Data;
using IQ_Test.Dtos;
using IQ_Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IQ_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepo _repo;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //Get api/question
        [HttpGet]
        public ActionResult<IEnumerable<QuestionReadDto>> GetAllQuestions()
        {
            var questionItems = _repo.GetAllQuestions();
            return Ok(_mapper.Map<IEnumerable<QuestionReadDto>>(questionItems));
        }

        //Get api/question/{id}
        [HttpGet("{id}", Name = "GetQuestionById")]
        public ActionResult<QuestionReadDto> GetQuestionById(int id)
        {
            var questionItem = _repo.GetQuestionById(id);
            if (questionItem != null)
            {
                return Ok(_mapper.Map<QuestionReadDto>(questionItem));
            }
            return NotFound();
        }

        //POST api/question
        [HttpPost]
        public ActionResult<QuestionReadDto> CreateQuestion(QuestionCreateDto questionCreateDto)
        {
            var questionModel = _mapper.Map<QuestionModel>(questionCreateDto);
            _repo.CreateQuestion(questionModel);
            _repo.SaveChanges();

            var questionReadDto = _mapper.Map<QuestionReadDto>(questionModel);

            return CreatedAtRoute(nameof(GetQuestionById), new { Id = questionReadDto.Qid }, questionReadDto);
        }

        //PUT api/question/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateQuestion(int id, QuestionUpdateDto questionUpdateDto)
        {
            var questionModelFromRepo = _repo.GetQuestionById(id);

            if (questionModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(questionUpdateDto, questionModelFromRepo);
            _repo.UpdateQuestion(questionModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }

        //PATCH api/question/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialQuestionUpdate(int id, JsonPatchDocument<QuestionUpdateDto> patchDoc)
        {
            var questionModelFromRepo = _repo.GetQuestionById(id);
            if (questionModelFromRepo == null)
            {
                return NotFound();
            }

            var questionToPatch = _mapper.Map<QuestionUpdateDto>(questionModelFromRepo);
            patchDoc.ApplyTo(questionToPatch, ModelState);
            if(!TryValidateModel(questionToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(questionToPatch, questionModelFromRepo);
            _repo.UpdateQuestion(questionModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }

        //DELETE api/question/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteQuestion(int id)
        {
            var questionModelFromRepo = _repo.GetQuestionById(id);
            if (questionModelFromRepo == null)
            {
                return NotFound();
            }

            _repo.DeleteQuestion(questionModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}

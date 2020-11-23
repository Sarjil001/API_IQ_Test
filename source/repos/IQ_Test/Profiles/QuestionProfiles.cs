using AutoMapper;
using IQ_Test.Dtos;
using IQ_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQ_Test.Profiles
{
    public class QuestionProfiles : Profile
    {
        public QuestionProfiles()
        {
            //Source -> Target
            CreateMap<QuestionModel, QuestionReadDto>();
            CreateMap<QuestionCreateDto, QuestionModel>();
            CreateMap<QuestionUpdateDto, QuestionModel>();
            CreateMap<QuestionModel, QuestionUpdateDto>();
        }
    }
}

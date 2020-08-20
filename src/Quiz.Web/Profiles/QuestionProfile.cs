using AutoMapper;
using Quiz.Application.Models;
using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Web.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionDto>()
                .ForMember(d => d.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(d => d.Options, opt => opt.MapFrom(src => src.QuestionOptions.Select(o => o.Option.Content)));
        }
    }
}

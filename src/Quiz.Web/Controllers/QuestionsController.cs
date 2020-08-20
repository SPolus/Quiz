using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quiz.Application.Models;
using Quiz.Domain.Entities;
using Quiz.Domain.Interfaces;
using Quiz.Infrastructure.Data;

namespace Quiz.Web.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        private readonly IQuestionRepository _repository;
        private readonly IMapper _mapper;

        public QuestionsController(IQuestionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var questions = await _repository.GetAllAsync(includeOptions: true);
            return View(_mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDto>>(questions));
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var question = await _repository.GetByIdAsync(id, includeOptions: true);

            if (question == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Question, QuestionDto>(question));
        }

        // GET: Questions/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _repository.GetAllCategories();
            var options = await _repository.GetAllOptions();

            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
            return View();
        }
    }
}

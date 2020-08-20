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

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content,CategoryId,Id")] Question question)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(question);
                
                return RedirectToAction(nameof(Index));
            }

            var categories = await _repository.GetAllCategories();

            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", question.CategoryId);
            return View(question);
        }

        //// GET: Questions/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var question = await _context.Questions.FindAsync(id);
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", question.CategoryId);
        //    return View(question);
        //}

        //// POST: Questions/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Content,CategoryId,Id")] Question question)
        //{
        //    if (id != question.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(question);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!QuestionExists(question.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", question.CategoryId);
        //    return View(question);
        //}

        //// GET: Questions/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var question = await _context.Questions
        //        .Include(q => q.Category)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(question);
        //}

        //// POST: Questions/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var question = await _context.Questions.FindAsync(id);
        //    _context.Questions.Remove(question);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool QuestionExists(int id)
        //{
        //    return _context.Questions.Any(e => e.Id == id);
        //}
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoRepository _repo;

        public ToDoController(ToDoRepository repository)
        {
            _repo = repository;
        }

        public async Task<IActionResult> Index()
        {
            var todos = await _repo.GetAllAsync();
            return View(todos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                await _repo.AddAsync(todoItem);
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        [HttpPut]
        public async Task<IActionResult> Toggle(string Id)
        {
            var todo = await _repo.GetByIdAsync(Id);
            if (todo != null && !todo.IsCompleted)
            {
                todo.IsCompleted = true;
                await _repo.UpdateAsync(Id, todo);
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            var todo = await _repo.GetByIdAsync(Id);
            if (todo != null)
            {
                await _repo.DeleteAsync(Id);
            }
            return Ok();
        }
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        public async Task<IActionResult> Toggle(ObjectId Id)
        {
            var todo = await _repo.GetByIdAsync(Id);
            if (todo != null && !todo.IsCompleted)
            {
                todo.IsCompleted = true;
                await _repo.UpdateAsync(todo);
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ObjectId Id)
        {
            var todo = await _repo.GetByIdAsync(Id);
            if (todo != null)
            {
                await _repo.DeleteAsync(Id);
            }
            return Ok();
        }

        public async Task<IActionResult> Edit(ObjectId Id)
        {
            var todo = await _repo.GetByIdAsync(Id);
            if (todo == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ToDoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                await _repo.UpdateAsync(todoItem);
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }
    }
}

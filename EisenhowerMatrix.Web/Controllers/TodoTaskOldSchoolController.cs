using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EisenhowerMatrix.BusinessLogic;
using EisenhowerMatrix.BusinessLogic.Models;
using EisenhowerMatrix.Entities;
using EisenhowerMatrix.Web.Models.TodoTaskOldSchool;
using Microsoft.AspNetCore.Mvc;

namespace EisenhowerMatrix.Web.Controllers
{
    public class TodoTaskOldSchoolController : Controller
    {
        private ITodoTaskService todoTaskService;

        public TodoTaskOldSchoolController(ITodoTaskService todoTaskService)
        {
            this.todoTaskService = todoTaskService;
        }

        public async Task<IActionResult> Index(CancellationToken token)
        {
            var tasks = await this.todoTaskService.GetAsync(new ToDoTaskFilter
            {
                ShowOnlyNonFinished = false
            }, token);

            var indexModel = new IndexModel();
            indexModel.Tasks = tasks.Select(x => new TaskModel
            {
                Id = x.Id,
                Name = x.Name,
                Urgency = x.Urgency,
                Importance = x.Importance,
                IsFinished = x.IsFinished
            }).ToList();

            return View(indexModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateTaskModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskModel model, CancellationToken token)
        {
            if (ModelState.IsValid)
            {
                await this.todoTaskService.CreateAsync(new TodoTask
                {
                    Name = model.Name,
                    Urgency = model.Urgency,
                    Importance = model.Importance,
                    IsFinished = false
                }, token);

                return RedirectToAction(nameof(Index));
            }
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            var task = await this.todoTaskService.GetAsync(id, token);

            if (task != null)
            {
                await this.todoTaskService.DeleteAsync(task, token);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsFinished(int id, CancellationToken token)
        {
            var task = await this.todoTaskService.GetAsync(id, token);

            if (task != null)
            {
                task.IsFinished = true;
                await this.todoTaskService.UpdateAsync(task, token);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsNotFinished(int id, CancellationToken token)
        {
            var task = await this.todoTaskService.GetAsync(id, token);

            if (task != null)
            {
                task.IsFinished = false;
                await this.todoTaskService.UpdateAsync(task, token);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

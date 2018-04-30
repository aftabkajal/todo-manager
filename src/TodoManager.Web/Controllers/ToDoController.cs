using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TodoManager.Core.Entities;
using TodoManager.Core.Interfaces;
using TodoManager.Infrastructure.Data;

namespace TodoManager.Web.Controllers
{

    [HandleError]
    public class ToDoController : Controller
    {
        private IAsyncRepository<ToDoItem> _repository;

        
        public ToDoController(IAsyncRepository<ToDoItem> repository)
        {
            this._repository = repository;
        }
        public ToDoController()
        {
            _repository = new EfRepository<ToDoItem>();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var toDoIteam = await _repository.ListAllAsync();
            return View(toDoIteam);
        }

        [HttpGet]
         public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var todoItem = await _repository.GetByIdAsync(id);
            return View(todoItem);
        }

        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDoItem ToDoItem)
        {
            try
            {
               if(ToDoItem == null)
                {
                    return RedirectToAction("Create");
                }

               await _repository.AddAsync(ToDoItem);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet] 
        public async Task<ActionResult> Edit(int id)
        {
            var toDoEntity = await _repository.GetByIdAsync(id);
            if(toDoEntity == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(toDoEntity);
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ToDoItem todoItem)
        {
            try
            {
                if (id == todoItem.Id)
                {
                   await _repository.UpdateAsync(todoItem);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if(entity == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(entity);
        }

        // POST: ToDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id, ToDoItem entity)
        {
            try
            {
                if(id == entity.Id)
                {
                   await _repository.DeleteAsync(entity);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

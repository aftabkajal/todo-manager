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

        // GET: ToDo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        [HttpPost]
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ToDo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

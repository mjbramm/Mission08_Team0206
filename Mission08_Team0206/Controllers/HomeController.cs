using Mission08_Team0206.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Mission08_Team0206.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Cats = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", new TaskModel());
        }

        [HttpPost]
        public IActionResult AddTask(TaskModel response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddATask(response);
                return RedirectToAction("Quadrants");
            }
            else
            {
                ViewBag.Cats = _repo.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult Quadrants()
        {
            var list = _repo.Tasks
                .Where(x => x.TaskName != null)
                .OrderBy(x => x.TaskName).ToList();

            return View(list);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.CategoryID == id);

            ViewBag.Cats = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Update(TaskModel updatedInfo)
        {
            _repo.EditATask(updatedInfo);

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Tasks
                .Single(x => x.CategoryID == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(TaskModel deleteRow)
        {
            _repo.DeleteATask(deleteRow);

            return RedirectToAction("Quadrants");
        }

    }
}

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

        //Add task action to link form
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Cats = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", new TaskModel());
        }
        //Add task action to post the form edit
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
        // Quadrant action to display to the list of quadrants
        public IActionResult Quadrants()
        {
            var list = _repo.Tasks
                .Where(x => x.TaskName != null)
                .OrderBy(x => x.TaskName).ToList();

            return View(list);
        }

        //Action to pull in the row we want to edit
        [HttpGet]
        public IActionResult Update(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskID == id);

            ViewBag.Cats = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", recordToEdit);
        }
        //Action to edit the row we want to edit
        [HttpPost]
        public IActionResult Update(TaskModel updatedInfo)
        {
            _repo.EditATask(updatedInfo);

            return RedirectToAction("Quadrants");
        }
        //Action to confrm to delete the right row
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Tasks
                .Single(x => x.TaskID == id);

            return View("Delete", recordToDelete);
        }
        // Action to actually delete the row
        [HttpPost]
        public IActionResult Delete(TaskModel deleteRow)
        {
            _repo.DeleteATask(deleteRow);

            return RedirectToAction("Quadrants");
        }

    }
}

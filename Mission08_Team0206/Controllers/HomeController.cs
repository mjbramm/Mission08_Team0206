using Mission08_Team0206.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Mission08_Team0206.Controllers
{
    public class HomeController : Controller
    {
        private TaskDbContext _context;

        public HomeController(TaskDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Cats = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", new Task());
        }

        [HttpPost]
        public IActionResult AddTask(Task response)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(response);
                _context.SaveChanges();
                return RedirectToAction("Quadrants");
            }
            else
            {
                ViewBag.Cats = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult Quadrants()
        {
            var list = _context.Tasks
                .Where(x => x.TaskName != null)
                .OrderBy(x => x.TaskName).ToList();

            return View(list);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var recordToEdit = _context.Tasks
                .Single(x => x.CategoryID == id);

            ViewBag.Cats = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Update(Task updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Tasks
                .Single(x => x.CategoryID == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Task deleteRow)
        {
            _context.Tasks.Remove(deleteRow);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }

    }
}

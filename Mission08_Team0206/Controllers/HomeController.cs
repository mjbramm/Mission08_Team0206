using Microsoft.AspNetCore.Mvc;
using Mission08_Team0206.Models;
using System.Diagnostics;

namespace Mission08_Team0206.Controllers
{
    public class HomeController : Controller
    {
        private TaskDBContext context;

        public HomeController(TaskDBContext temp)
        {
            context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTask()
        {
            return View();
        }

}

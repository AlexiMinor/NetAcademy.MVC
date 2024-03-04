using Microsoft.AspNetCore.Mvc;
using NetAcademy.UI.Models;
using System.Diagnostics;

namespace NetAcademy.UI.Controllers
{
    //public class HomeController .... SomeName[Controller]
    //[Controller]
    //[NonController]

    //GET, POST, PUT, PATCH, DELETE, HEAD, OPTIONS
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[NonAction]
        [HttpGet]
        public IActionResult Index()
        {
            var dataFromQuery = Request.Query;
            return View();
        }
        //route, forms, body, headers 

        //[ActionName("SomeTest")]
        [HttpPost]
        public IActionResult Test()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Test2(PersonModel person)
        {
                return Ok(
                    new
                    {
                        person.Name,
                        person.Age,
                        person.Email
                    });
        }

        [HttpGet]
        public IActionResult Test3(PersonModel[] persons)
        {
            return Ok(
                persons
                    .Select(person => 
                        new { person.Name, person.Age, person.Email })
                    .ToArray());
        }

        [HttpGet]
        public IActionResult Test4(Dictionary<string, string> data)
        {
            return Ok(data);

        }

        // GET, POST, DELETE, PUT, (PATCH?)
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using HealthCareManagement.Models;

namespace HealthCareManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewP()
        {
            //_logger.LogDebug("Get patient info");
            var a = Enumerable.Range(1, 5).Select(index => new Patient
            {
                PatientId = Random.Shared.Next(),
                PatientName = "abcd",
                //Age = new Random().Next(10, 50)

                //Date = DateTime.Now.AddDays(index),
                //TemperatureC = Random.Shared.Next(-20, 55),
                //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            return View(a);
        }
    }
}

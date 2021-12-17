using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using PeopleManager.Models;
using PeopleManager.Services;

namespace PeopleManager.Controllers
{
	public class HomeController : Controller
	{
		private readonly PersonService _personService;

		public HomeController(PersonService personService)
        {
            _personService = personService;
        }

		public IActionResult Index()
		{
			var people = _personService.Find();
			return View(people);
		}

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

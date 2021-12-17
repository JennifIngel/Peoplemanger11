using Microsoft.AspNetCore.Mvc;
using PeopleManager.Model;
using PeopleManager.Services;

namespace PeopleManager.Controllers
{
	public class PeopleController : Controller
	{
		private readonly PersonService _personService;

		public PeopleController(PersonService personService)
		{
            _personService = personService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var people = _personService.Find();
			return View(people);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Person person)
		{
            if (!ModelState.IsValid)
            {
				return View(person);
            }

            var newPerson = _personService.Create(person);
            if (newPerson is null)
            {
				ModelState.AddModelError("", "Something went wrong");
                return View(person);
            }

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
        {
            var person = _personService.Get(id);

			if (person is null)
			{
				return RedirectToAction("Index");
			}
			
			return View(person);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit([FromRoute]int id, [FromForm]Person person)
		{
			if (!ModelState.IsValid)
			{
				return View(person);
			}

            var dbPerson = _personService.Update(id, person);

			if (dbPerson is null)
			{
                ModelState.AddModelError("", "Something went wrong");
                return View(person);
			}
			
			return RedirectToAction("Index");
		}

		[HttpGet]
        public IActionResult Delete(int id)
        {
            var person = _personService.Get(id);
            if (person is null)
            {
                return RedirectToAction("Index");
            }
			
            return View(person);
        }

        [HttpPost("People/Delete/{id?}")]
		[ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _personService.Delete(id);
            return RedirectToAction("Index");
        }

		
	}
}

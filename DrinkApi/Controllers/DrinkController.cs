using Microsoft.AspNetCore.Mvc;
using DrinkApi.Services;
using DrinkApi.Models;

namespace DrinkApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DrinkController(DrinkService drinkService) : ControllerBase
	{
		private readonly DrinkService _drinkService = drinkService;

		[HttpGet]
		public IActionResult GetAll()
		{
			var drinks = _drinkService.GetAll();
			return Ok(drinks);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var drink = _drinkService.GetById(id);
			if (drink == null)
			{
				return NotFound();
			}
			return Ok(drink);
		}

		[HttpPost]
		public IActionResult Create(Drink newDrink)
		{
			var createdDrink = _drinkService.Create(newDrink);
			return CreatedAtAction(nameof(GetById), new { id = createdDrink.Id }, createdDrink);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, Drink updatedDrink)
		{
			try
			{
				_drinkService.Update(id, updatedDrink);
				return NoContent();
			}
			catch (InvalidOperationException ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_drinkService.Delete(id);
			return NoContent();
		}
	}
}

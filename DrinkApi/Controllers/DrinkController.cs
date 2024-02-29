using DrinkApi.Models;
using DrinkApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DrinkApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DrinkController : ControllerBase
{
	public DrinkController()
	{

	}
	[HttpGet]
	public ActionResult<List<Drink>> GetAll() =>
		DrinkService.GetAll();

	[HttpGet("{id}")]
	public ActionResult<Drink> Get(int id)
	{
		var drink = DrinkService.Get(id);

		if (drink is null)
			return NotFound();

		return drink;
	}

	[HttpPost]
	public IActionResult Create(Drink drink)
	{
		DrinkService.Add(drink);
		return CreatedAtAction(nameof(Get), new { id = drink.Id }, drink);
	}

	[HttpPut("{id}")]
	public IActionResult Update(int id, Drink drink)
	{
		if (id != drink.Id)
		{
			return BadRequest();
		}

		var existingDrink = DrinkService.Get(id);

		if (existingDrink is null)
		{
			return NotFound();
		}

		DrinkService.Update(drink);

		return NoContent();
	}

	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
	{
		var drink = DrinkService.Get(id);
		if (drink is null)
		{
			return NotFound();
		}

		DrinkService.Delete(id);

		return NoContent();
	}
}
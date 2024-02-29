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

		if (drink == null)
			return NotFound();

		return drink;
	}
}
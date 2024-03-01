using GuitarApi.Models;
using GuitarApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuitarApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GuitarController : ControllerBase
{
	public GuitarController()
	{
	}

	[HttpGet]
	public ActionResult<List<Guitar>> GetAll() =>
		GuitarService.GetAll();

	[HttpGet("{id}")]
	public ActionResult<Guitar> Get(int id)
	{
		var guitar = GuitarService.Get(id);

		if (guitar == null)
			return NotFound();

		return guitar;
	}

	[HttpPost]
	public IActionResult Create(Guitar guitar)
	{
		GuitarService.Add(guitar);
		return CreatedAtAction(nameof(Get), new { id = guitar.Id }, guitar);
	}

	[HttpPut("{id}")]
	public IActionResult Update(int id, Guitar guitar)
	{
		if (id != guitar.Id)
			return BadRequest();

		var existingGuitar = GuitarService.Get(id);
		if (existingGuitar is null)
			return NotFound();

		GuitarService.Update(guitar);

		return NoContent();
	}

	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
	{
		var guitar = GuitarService.Get(id);

		if (guitar is null)
			return NotFound();

		GuitarService.Delete(id);

		return NoContent();
	}
}
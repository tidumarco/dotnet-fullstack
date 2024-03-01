using GuitarApi.Models;
using GuitarApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuitarApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GuitarController : ControllerBase
{
	private readonly GuitarService _service;
	public GuitarController(GuitarService service)
	{
		_service = service;
	}

	[HttpGet]
	public IEnumerable<Guitar> GetAll()
	{
		return _service.GetAll();
	}

	[HttpGet("{id}")]
	public ActionResult<Guitar> GetById(int id)
	{
		var guitar = _service.GetById(id);

		if (guitar is not null)
		{
			return guitar;
		}
		else
		{
			return NotFound();
		}
	}

	[HttpPost]
	public IActionResult Create(Guitar guitar)
	{
		_service.Create(guitar);
		return CreatedAtAction(nameof(GetById), new { id = guitar.Id }, guitar);
	}

	[HttpPut("{id}")]
	public IActionResult Update(int id, Guitar guitar)
	{
		var guitarToUpdate = _service.GetById(id);

		if (guitarToUpdate is not null)
		{
			_service.Update(id, guitar);
			return NoContent();
		}
		else
		{
			return NotFound();
		}

	}

	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
	{
		var guitar = _service.GetById(id);

		if (guitar is not null)
		{
			_service.DeleteById(id);
			return NoContent();
		}
		else
		{
			return NotFound();
		}

	}
}
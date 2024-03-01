using GuitarApi.Models;
using GuitarApi.Data;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace GuitarApi.Services;

public class GuitarService
{
	private readonly GuitarContext _context;
	public GuitarService(GuitarContext context)
	{
		_context = context;
	}

	public IEnumerable<Guitar> GetAll()
	{
		return _context.Guitars.AsNoTracking().ToList();
	}

	public Guitar? GetById(int id)
	{
		return _context.Guitars.Find(id);
	}

	public Guitar Create(Guitar newGuitar)
	{
		_context.Guitars.Add(newGuitar);
		_context.SaveChanges();

		return newGuitar;
	}

	public void DeleteById(int id)
	{
		var guitarToDelete = _context.Guitars.Find(id);
		if (guitarToDelete is not null)
		{
			_context.Guitars.Remove(guitarToDelete);
			_context.SaveChanges();
		}


	}

	public void Update(int guitarId, Guitar updatedGuitar)
	{
		var existingGuitar = _context.Guitars.Find(guitarId);

		if (existingGuitar != null)
		{
			existingGuitar.Name = updatedGuitar.Name;
			existingGuitar.Description = updatedGuitar.Description;
			existingGuitar.Price = updatedGuitar.Price;

			_context.SaveChanges();
		}
	}
}
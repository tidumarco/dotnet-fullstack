using DrinkApi.Models;
using DrinkApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinkApi.Services;

public class DrinkService(DrinkContext context)
{
	private readonly DrinkContext _context = context;

	[HttpGet]
	public IEnumerable<Drink> GetAll()
	{
		return _context.Drinks
		.AsNoTracking()
		.ToList();
	}

	[HttpGet("{id}")]
	public Drink? GetById(int id)
	{
		return _context.Drinks
		.Include(d => d.StrDrink)
		.Include(d => d.StrDrinkThumb)
		.AsNoTracking()
		.SingleOrDefault(d => d.Id == id);
	}

	[HttpPost]
	public Drink Create(Drink newDrink)
	{
		_context.Drinks.Add(newDrink);
		_context.SaveChanges();
		return newDrink;
	}

	[HttpPut("{id}")]
	public void Update(int id, Drink updatedDrink)
	{
		var drinkToUpdate = _context.Drinks.Find(id) ?? throw new InvalidOperationException("Drink does not exist.");
		_context.Update(drinkToUpdate);

		_context.SaveChanges();
	}

	[HttpDelete("{id}")]
	public void Delete(int id)
	{
		var drinkToDelete = _context.Drinks.Find(id);
		if (drinkToDelete is not null)
		{
			_context.Drinks.Remove(drinkToDelete);
			_context.SaveChanges();
		}
	}
}
using GuitarApi.Models;

namespace GuitarApi.Services;

public static class GuitarService
{
	static List<Guitar> Guitars { get; }
	static int nextId = 3;
	static GuitarService()
	{
		Guitars = new List<Guitar>
		{
			new Guitar {Id = 1, Name = "Fender Stratocaster", Description = "Best solo guitar", Price = 1299},
			new Guitar {Id = 2, Name = "Gibson Les Paul", Description = "A rock legend", Price = 1999},
		};
	}

	public static List<Guitar> GetAll() => Guitars;

	public static Guitar? Get(int id) => Guitars.FirstOrDefault(g => g.Id == id);

	public static void Add(Guitar guitar)
	{
		guitar.Id = nextId++;
		Guitars.Add(guitar);
	}

	public static void Delete(int id)
	{
		var guitar = Get(id);
		if (guitar is null)
			return;

		Guitars.Remove(guitar);
	}

	public static void Update(Guitar guitar)
	{
		var index = Guitars.FindIndex(p => p.Id == guitar.Id);
		if (index == -1)
			return;

		Guitars[index] = guitar;
	}
}
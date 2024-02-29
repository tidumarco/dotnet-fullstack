using System.Data;
using System.Net.NetworkInformation;
using DrinkApi.Models;

namespace DrinkApi.Services;

public static class DrinkService
{
	private static List<Drink> Drinks { get; }
	private static int nextId = 4;
	static DrinkService()
	{
		Drinks =
		[
			new() {Id = 1, StrDrink = "Bleeding Surgeon", StrDrinkThumb="DrinkApi/Images/bleedin_surgeon.jpeg"},
			new() {Id = 2, StrDrink = "Furlong", StrDrinkThumb="DrinkApi/Images/furlong.jpeg"},
			new() {Id = 3, StrDrink = "Jack Vanilla", StrDrinkThumb="DrinkApi/Images/jack_vanilla.jpeg"},
		];
	}

	public static List<Drink> GetAll() => Drinks;

	public static Drink? Get(int id) => Drinks.Find(d => d.Id == id);

	public static void Add(Drink drink)
	{
		drink.Id = nextId++;
		Drinks.Add(drink);
	}

	public static void Delete(int id)
	{
		var drink = Get(id);
		if (drink is null)
		{
			return;
		}

		Drinks.Remove(drink);
	}

	public static void Update(Drink drink)
	{
		var index = Drinks.FindIndex(d => d.Id == drink.Id);
		if (index == -1)
		{
			return;
		}

		Drinks[index] = drink;
	}
}
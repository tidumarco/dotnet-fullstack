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
			new() {Id = 1, StrDrink = "Bleeding Surgeon", StrDrinkThumb="https://cocktail-stack.netlify.app/static/9a9686fb30894c841b2b4b3ce366659c/9a128/usuvvr1472719118.jpg"},
			new() {Id = 2, StrDrink = "Furlong", StrDrinkThumb="https://cocktail-stack.netlify.app/static/e5e7592566b139924a68c8edb05e0c8c/9a128/ssxvww1472669166.jpg"},
			new() {Id = 3, StrDrink = "Jack Vanilla", StrDrinkThumb="https://cocktail-stack.netlify.app/static/a5b08ad08fd68557ecf5dfdfb7a5d41a/9a128/kjnt7z1504793319.jpg"},
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
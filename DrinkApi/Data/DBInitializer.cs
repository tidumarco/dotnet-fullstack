using DrinkApi.Models;
using DrinkApi.Services;

namespace DrinkApi.Data
{
	public static class DbInitializer
	{
		public static void Initalize(DrinkContext context)
		{
			if (context.Drinks.Any())
			{
				return;
			}

			var drinks = new Drink[]
			{
				new() {StrDrink="Malibu", StrDrinkThumb="url here" },
				new() {StrDrink="Long Island", StrDrinkThumb="url here" },
				new() {StrDrink="Cuba Libre", StrDrinkThumb="url here" }
			};

			context.Drinks.AddRange(drinks);
			context.SaveChanges();
		}
	}
}
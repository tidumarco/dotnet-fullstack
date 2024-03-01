using GuitarApi.Models;

namespace GuitarApi.Data
{
	public static class DbInitializer
	{
		public static void Initialize(GuitarContext context)
		{
			if (context.Guitars.Any())
			{
				return;
			}

			var guitars = new Guitar[]{
				new() {Name = "Fender Stratocaster", Description = "Best solo guitar in history", Price = 1299},
				new() {Name = "Gibson Les Paul", Description = "Solid Body guitar", Price = 1999},
				new() {Name = "Ibanez RG 570", Description = "Shredding guitar", Price = 999},
			};

			context.Guitars.AddRange(guitars);
			context.SaveChanges();
		}
	}
}
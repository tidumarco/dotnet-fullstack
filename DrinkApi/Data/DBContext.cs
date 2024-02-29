using Microsoft.EntityFrameworkCore;
using DrinkApi.Models;

namespace DrinkApi.Data
{
	public class DrinkContext : DbContext
	{
		public DrinkContext(DbContextOptions<DrinkContext> options) : base(options)
		{
		}
		public DbSet<Drink> Drinks => Set<Drink>();
	}
}
using Microsoft.EntityFrameworkCore;
using GuitarApi.Models;

namespace GuitarApi.Data;

public class GuitarContext : DbContext
{
	public GuitarContext(DbContextOptions<GuitarContext> options)
		: base(options)
	{
	}
	public DbSet<Guitar> Guitars => Set<Guitar>();
}
using Microsoft.EntityFrameworkCore;

namespace DrinkApi.Data;

public static class Extensions
{
	public static void CreateDbIfNotExists(this IHost host)
	{
		using var scope = host.Services.CreateScope();
		var services = scope.ServiceProvider;
		var context = services.GetRequiredService<DrinkContext>();
		context.Database.EnsureCreated();
		DbInitializer.Initalize(context);
	}
}
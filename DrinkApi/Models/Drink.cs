using System.ComponentModel.DataAnnotations;

namespace DrinkApi.Models;
public class Drink
{
	[Key]
	public int? Id { get; set; }
	[MaxLength(50)]
	public string? StrDrink { get; set; }
	public string? StrDrinkThumb { get; set; }

};
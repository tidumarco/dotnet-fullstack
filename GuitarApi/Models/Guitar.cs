using System.ComponentModel.DataAnnotations;

namespace GuitarApi.Models;

public class Guitar
{
	public int Id { get; set; }
	[Required]
	[MaxLength(100)]
	public string? Name { get; set; }
	public string? Description { get; set; }
	public double? Price { get; set; }
}
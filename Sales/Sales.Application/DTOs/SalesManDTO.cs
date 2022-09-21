using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sales.Application.DTOs;

public class SalesManDTO
{
	public int Id { get; set; }

	[Required(ErrorMessage = "The Name is required")]
	[DisplayName("Name")]
	public string? Name { get; set; }

	[Required(ErrorMessage = "The cpf is required")]
	[MinLength(11)]
	[DisplayName("CPF")]
	public string Cpf { get; set; }

	[Required(ErrorMessage = "The email is required")]
	[DisplayName("Email")]
	public string Email { get; set; }

	[Required(ErrorMessage = "The phone is required")]
	[DisplayName("Phone")]
	public string Phone { get; set; }
}

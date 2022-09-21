using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sales.Application.DTOs;

public class SaleItemDTO
{
	[Required(ErrorMessage = "Quantity is required")]
	[DisplayName("Quantity")]
	public int Quantity { get; set; }

	[Required(ErrorMessage = "UnitValue is required")]
	[DisplayName("UnitValue")]
	public decimal UnitValue { get; set; }
	public int ProductId { get; set; }

}

using Sales.Domain.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sales.Application.DTOs;

public class SaleDTO
{
	[Required(ErrorMessage = "SaleMan is required")]
	[DisplayName("SalesMan")]
	public SalesManDTO SalesMan { get; set; }

	[Required(ErrorMessage = "SaleDate is required")]
	[DisplayName("SalesDate")]
	public DateTime SaleDate { get; set; }

	[Required(ErrorMessage = "Itens is required")]
	[DisplayName("Itens")]
	public List<SaleItemDTO> Itens { get; set; }

	[Required(ErrorMessage = "Status is required")]
	[DisplayName("Status")]
	public Status StatusSale { get; set; }
}

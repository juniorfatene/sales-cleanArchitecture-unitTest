using Sales.Domain.Enum;
using Sales.Domain.Validation;

namespace Sales.Domain.Entities;

public sealed class Sale : Entity
{
	public int SalesManId { get; private set; }
	public SalesMan SalesMan { get; private set; }
	public DateTime SaleDate { get; private set; }
	public List<SaleItem> Itens { get; private set; }
	public Status StatusSale { get; private set; } = Status.AwaitingPayment;


	public Sale(SalesMan salesMan, DateTime saleDate, List<SaleItem> itens)
	{	
		SalesMan = salesMan;
		SaleDate = saleDate;
		Itens = itens;
		ValidateDomain();
	}

	private Sale()
	{ }

	private void ValidateDomain()
	{
		DomainExceptionValidation.When(SalesMan == null,
			"SalesMan is required");

		DomainExceptionValidation.When(SaleDate.ToString() == null,
			"Date is required");

		DomainExceptionValidation.When(Itens.Count() < 1, "Sale without items");

	}

	public void ChangeStatusSales(Status statusSales)
	{
		if (StatusSale == Status.AwaitingPayment && (statusSales == Status.Approved || statusSales == Status.Canceled)) 
		{
			StatusSale = statusSales;
			return;
		}

		if (StatusSale == Status.Approved && (statusSales == Status.Canceled || statusSales == Status.SentToCarrier))
		{
			StatusSale = statusSales;
			return;
		}

		if (StatusSale == Status.SentToCarrier && statusSales == Status.Delivered)
		{
			StatusSale = statusSales;
			return;
		}

		throw new NotChangedSalesStatusException($"Cannot change status from {StatusSale} to {statusSales}");
	}
	
	public void ChangeSales(SalesMan salesMan, List<SaleItem> itens)
	{
		SalesMan = salesMan;
		Itens = itens;
	}
}
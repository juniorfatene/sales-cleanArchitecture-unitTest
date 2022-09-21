using Sales.Domain.Validation;

namespace Sales.Domain.Entities;

public sealed class SaleItem : Entity
{
	public SaleItem(int quantity, decimal unitValue)
	{
		Quantity = quantity;
		UnitValue = unitValue;
		ValidateDomain();

	}

	public int Quantity { get; private set; }
	public decimal UnitValue { get; private set; }


	public int SaleId { get; set; }
	public Sale Sale { get; private set; }
	public int ProductId { get; private set; }
	public Product Product { get; private set; }


	private void ValidateDomain()
	{
		DomainExceptionValidation.When(Quantity < 1,
			"Invalid quantity");

		DomainExceptionValidation.When(UnitValue < 0,
			"Invalid unit value");
	}
}

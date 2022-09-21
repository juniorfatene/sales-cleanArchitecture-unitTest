using Sales.Domain.Validation;

namespace Sales.Domain.Entities;

public sealed class Product : Entity
{
	public string Name { get; private set; }

	public List<SaleItem> Itens { get; private set; }

	public Product(string name)
	{
		Itens = new List<SaleItem>();
		Name = name;
		ValidateDomain();
	}

	private Product()
	{ }

	private void ValidateDomain()
	{
		DomainExceptionValidation.When(string.IsNullOrEmpty(Name),
			"Name is required");
	}
}

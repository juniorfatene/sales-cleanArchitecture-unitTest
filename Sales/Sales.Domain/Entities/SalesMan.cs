using Sales.Domain.Validation;

namespace Sales.Domain.Entities;

public sealed class SalesMan : Entity
{
	public string Name { get; private set; }
	public string Cpf { get; private set; }
	public string Email { get; private set; }
	public string Phone { get; private set; }
	public List<Sale> Sales { get; private set; }


	public SalesMan(string name, string cpf, string email, string phone)
	{
		Name = name;
		Cpf = cpf;
		Email = email;
		Phone = phone;
		ValidateDomain();
	}

	private SalesMan()
	{ }


	private void ValidateDomain()
	{
		DomainExceptionValidation.When(string.IsNullOrEmpty(Name),
			"Invalid name. Name is required");

		DomainExceptionValidation.When(Cpf.Length < 11,
			"Invalid cpf, too short, minimum 11 characters");

		DomainExceptionValidation.When(string.IsNullOrEmpty(Email),
			"Invalid email. Email is required");

		DomainExceptionValidation.When(string.IsNullOrEmpty(Phone),
			"Invalid phone. Phone is required");

	}
}

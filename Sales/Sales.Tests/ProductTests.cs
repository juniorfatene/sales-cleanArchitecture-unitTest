using Sales.Domain.Entities;
using FluentAssertions;
using AutoFixture;
using Xunit;

namespace Sales.Tests
{
	public class ProductTests
	{
		[Fact]
		public void CreateProduct_WithValidParameters_ResultObjectValid()
		{
			var product = new Product("junior");

			product.Should().NotBeNull();
			
		}

		[Fact]
		public void CreateProduct_WithNullName_DomainExceptionNameRequired()
		{
			Action action = () => new Product(null);

			action.Should().Throw<Domain.Validation.DomainExceptionValidation>();
		}
	}
}
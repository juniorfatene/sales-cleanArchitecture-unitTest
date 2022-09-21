using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infra.Data.Map;

public class SalesItemMap : IEntityTypeConfiguration<SaleItem>
{
	public void Configure(EntityTypeBuilder<SaleItem> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Quantity)
			.HasColumnName("Quantity")
			.HasColumnType("int")
			.IsRequired();

		builder.Property(x => x.UnitValue)
			.HasColumnType("int")
			.IsRequired();

		builder.HasOne(x => x.Sale)
			.WithMany(x => x.Itens)
			.HasForeignKey(x => x.SaleId);

		builder.HasOne(x => x.Product)
			.WithMany(x => x.Itens)
			.HasForeignKey(x => x.ProductId);

	}
}

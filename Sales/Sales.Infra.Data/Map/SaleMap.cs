using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infra.Data.Map;

public class SaleMap : IEntityTypeConfiguration<Sale>
{
	public void Configure(EntityTypeBuilder<Sale> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.SaleDate)
			.HasColumnName("SaleDate")
			.HasColumnType("DateTime")
			.IsRequired();

		builder.Property(x => x.StatusSale)
			.HasColumnName("Status")
			.HasColumnType("int")
			.IsRequired();

		builder.HasOne(x => x.SalesMan)
			.WithMany(x => x.Sales)
			.HasForeignKey(x => x.SalesManId);
	}
}

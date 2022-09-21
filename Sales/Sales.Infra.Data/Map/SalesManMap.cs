using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infra.Data.Map;

public class SalesManMap : IEntityTypeConfiguration<SalesMan>
{
	public void Configure(EntityTypeBuilder<SalesMan> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Name)
			.HasColumnName("Name")
			.HasColumnType("varchar(100)")
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(x => x.Cpf)
			.HasColumnName("Cpf")
			.HasColumnType("varchar(11)")
			.IsRequired();

		builder.Property(x => x.Email)
			.HasColumnName("Email")
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(x => x.Phone)
			.HasColumnName("Phone")
			.HasColumnType("varchar(20)")
			.IsRequired();
	}
}

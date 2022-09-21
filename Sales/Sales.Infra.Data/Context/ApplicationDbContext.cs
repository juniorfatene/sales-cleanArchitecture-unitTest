using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;


namespace Sales.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{ }

	public DbSet<SalesMan> Salesman { get; set; }
	public DbSet<Sale> Sale { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<SaleItem> SaleItems { get; set; }


	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
	}

}

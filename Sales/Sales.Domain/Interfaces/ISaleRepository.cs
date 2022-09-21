using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces;

public interface ISaleRepository
{
	Task CreateSaleAsync(Sale sale);
	Task<Sale> GetByIdAsync(int id);
	Task UpdateSaleAsync(Sale sale);
}

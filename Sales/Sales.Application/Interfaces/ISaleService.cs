using Sales.Application.DTOs;

namespace Sales.Application.Interfaces;

public interface ISaleService
{
	Task<int> CreateSaleAsync(SaleDTO saleDTO, CancellationToken cancellationToken);
	Task<SaleDTO> GetByIdAsync(int id);
	Task UpdateSaleAsync(int id, SaleDTO saleDTO, CancellationToken cancellationToken);
}

using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Sales.Infra.Data.Repositories;

public class SaleRepository : ISaleRepository
{
	private ApplicationDbContext _saleRepository;

	public SaleRepository(ApplicationDbContext context)
	{
		_saleRepository = context;
	}

	public async Task CreateSaleAsync(Sale sale)
	{
		_saleRepository.Add(sale);
		//await _saleRepository.SaveChangesAsync();
	}

	public async Task<Sale> GetByIdAsync(int id)
	{
		return await _saleRepository.Sale.Include(x => x.SalesMan)
						.Include(x => x.Itens)
						.SingleOrDefaultAsync(x => x.Id == id);
	}

	public async Task UpdateSaleAsync(Sale sale)
	{
		_saleRepository.Update(sale);
		//await _saleRepository.SaveChangesAsync();
	}
}

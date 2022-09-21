using AutoMapper;
using Sales.Application.DTOs;
using Sales.Application.Interfaces;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services;

public class SaleService : ISaleService
{
	private readonly ISaleRepository _saleRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public SaleService(ISaleRepository saleRepository, IMapper mapper, IUnitOfWork unitOfWork)
	{
		_saleRepository = saleRepository;
		_mapper = mapper;
		_unitOfWork = unitOfWork;	
	}

	public async Task<int> CreateSaleAsync(SaleDTO saleDTO, CancellationToken cancellationToken)
	{
		var saleEntity = _mapper.Map<Sale>(saleDTO);
		await _saleRepository.CreateSaleAsync(saleEntity);
		await _unitOfWork.SaveAsync(cancellationToken);
		return saleEntity.Id;
	}

	public async Task<SaleDTO> GetByIdAsync(int id)
	{
		var saleEntity = await _saleRepository.GetByIdAsync(id);
		return _mapper.Map<SaleDTO>(saleEntity);
	}

	public async Task UpdateSaleAsync(int id, SaleDTO saleDTO, CancellationToken cancellationToken)
	{
		var entity = await _saleRepository.GetByIdAsync(id);
		entity.ChangeSales(_mapper.Map<SalesMan>(saleDTO.SalesMan), _mapper.Map<List<SaleItem>>(saleDTO.Itens));
		entity.ChangeStatusSales(saleDTO.StatusSale);
		await _saleRepository.UpdateSaleAsync(entity);
		await _unitOfWork.SaveAsync(cancellationToken);
	}
}

using AutoMapper;
using Sales.Application.DTOs;
using Sales.Domain.Entities;

namespace Sales.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
	public DomainToDTOMappingProfile()
	{
		CreateMap<Sale, SaleDTO>();

		CreateMap<SaleDTO, Sale>()
				.ForMember(x => x.StatusSale, x => x.Ignore());

		CreateMap<SalesMan, SalesManDTO>().ReverseMap();
		CreateMap<Product, ProductDTO>().ReverseMap();
		CreateMap<SaleItem, SaleItemDTO>().ReverseMap();
	}
}

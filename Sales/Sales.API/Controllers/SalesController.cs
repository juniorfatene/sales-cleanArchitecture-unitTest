using Microsoft.AspNetCore.Mvc;
using Sales.Application.DTOs;
using Sales.Application.Interfaces;

namespace Sales.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SalesController : ControllerBase
	{
		private readonly ISaleService _saleService;

		public SalesController(ISaleService saleService)
		{
			_saleService = saleService;
		}

		[HttpPost]
		[ProducesResponseType(typeof(SaleDTO), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Post(SaleDTO saleDTO, CancellationToken cancellationToken)
		{
			try
			{
				var id = await _saleService.CreateSaleAsync(saleDTO, cancellationToken);
				return Created($"api/sales/{id}", saleDTO);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(IEnumerable<SaleDTO>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<SaleDTO>> Get(int id)
		{
			try
			{
				var sale = await _saleService.GetByIdAsync(id);
				if (sale == null)
					return BadRequest("Sale not found");

				return Ok(sale);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPut("{id}")]
		[ProducesResponseType(typeof(SaleDTO), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Put(int id, SaleDTO saleDTO, CancellationToken cancellationToken)
		{
			try
			{ 
				await _saleService.UpdateSaleAsync(id,saleDTO, cancellationToken);
				return Ok(saleDTO);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}		
		}
	}
}

using Sales.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infra.Data.Context
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<bool> SaveAsync(CancellationToken cancelationToken)
		{
			return await _context.SaveChangesAsync(cancelationToken) > 0;
		}

		public void Dispose()
		{
			_context.Dispose();
		}

		
	}
}

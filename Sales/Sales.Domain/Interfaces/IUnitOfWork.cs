using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
	Task<bool> SaveAsync(CancellationToken cancellationToken);
}

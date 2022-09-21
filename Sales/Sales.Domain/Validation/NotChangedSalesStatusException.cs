
namespace Sales.Domain.Validation
{
	public class NotChangedSalesStatusException : Exception
	{
		public NotChangedSalesStatusException(string message)
			: base(message)
		{ }
	}
}

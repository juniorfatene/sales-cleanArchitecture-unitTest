namespace Sales.Domain.Enum
{
	public enum Status : short
	{
		AwaitingPayment = 1,
		Approved,
		SentToCarrier,
		Delivered,
		Canceled
	}
}

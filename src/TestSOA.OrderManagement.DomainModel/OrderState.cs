namespace TestSOA.OrderManagement.DomainModel
{
	public enum OrderState
	{
		Buffered,
		ReleasedToBlotter,
		Executed,
		Booked,
	}
}

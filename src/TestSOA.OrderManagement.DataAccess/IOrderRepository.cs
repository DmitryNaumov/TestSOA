namespace TestSOA.OrderManagement.DataAccess
{
	using TestSOA.DataAccess;
	using TestSOA.OrderManagement.DomainModel;

	public interface IOrderRepository : IRepository<Order>
	{
	}
}

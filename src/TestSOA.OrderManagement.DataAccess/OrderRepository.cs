namespace TestSOA.OrderManagement.DataAccess
{
	using NHibernate;
	using TestSOA.DomainModel;
	using TestSOA.OrderManagement.DomainModel;

	internal sealed class OrderRepository : IOrderRepository
	{
		private readonly ISession _session;

		public OrderRepository(ISession session)
		{
			_session = session;
		}

		public Order Get(EntityRef<Order> entityRef)
		{
			return _session.Get<Order>(entityRef.EntityId);
		}

		public void Save(Order entity)
		{
			_session.Save(entity);
		}
	}
}

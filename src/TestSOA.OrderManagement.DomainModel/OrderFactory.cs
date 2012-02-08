namespace TestSOA.OrderManagement.DomainModel
{
	using TestSOA.DomainModel;

	internal sealed class OrderFactory : IOrderFactory
	{
		public Order Create(EntityRef<Security> securityRef)
		{
			var order = new Order();
			order.InitializeWithSecurity(securityRef);
			return order;
		}
	}
}

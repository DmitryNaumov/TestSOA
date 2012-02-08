namespace TestSOA.OrderManagement.DomainModel
{
	using TestSOA.DomainModel;

	public sealed class Ticket : Entity<Ticket>
	{
		public override IAggregateRoot Root
		{
			get { return Order; }
		}

		public Order Order { get; private set; }
	}
}

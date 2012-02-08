namespace TestSOA.OrderManagement.DomainModel
{
	using TestSOA.Annotations;
	using TestSOA.DomainModel;

	public interface IOrderFactory
	{
		[NotNull]
		Order Create([NotNull] EntityRef<Security> security);
	}
}

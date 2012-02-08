namespace TestSOA.DomainModel
{
	using TestSOA.Annotations;

	public interface IEntity
	{
		[NotNull]
		IEntityRef Reference { get; }

		[NotNull]
		IAggregateRoot Root { get; }
	}
}

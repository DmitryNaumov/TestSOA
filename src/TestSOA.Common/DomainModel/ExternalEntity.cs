namespace TestSOA.DomainModel
{
	public abstract class ExternalEntity<TEntity> : AggregateRoot<TEntity>
		where TEntity : AggregateRoot<TEntity>
	{
	}
}

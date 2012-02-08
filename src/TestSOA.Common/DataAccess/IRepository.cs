namespace TestSOA.DataAccess
{
	using TestSOA.Annotations;
	using TestSOA.DomainModel;

	public interface IRepository<TEntity>
		where TEntity : AggregateRoot<TEntity>
	{
		TEntity Get([NotNull] EntityRef<TEntity> entityRef);

		void Save([NotNull] TEntity entity);
	}
}

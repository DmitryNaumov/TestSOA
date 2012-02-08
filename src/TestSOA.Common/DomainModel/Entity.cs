namespace TestSOA.DomainModel
{
	public abstract class Entity<TEntity> : DomainObject, IEntity
		where TEntity : Entity<TEntity>
	{
		public EntityRef<TEntity> Reference
		{
			get { return new EntityRef<TEntity>(EntityId); }
		}

		public abstract IAggregateRoot Root { get; }

		protected int EntityId { get; set; }

		IEntityRef IEntity.Reference
		{
			get { return Reference; }
		}
	}
}

namespace TestSOA.DomainModel
{
	using System;

	public sealed class EntityRef<TEntity> : IEntityRef, IComparable<EntityRef<TEntity>>, IEquatable<EntityRef<TEntity>>
		where TEntity : Entity<TEntity>
	{
		private readonly int _entityId;

		public EntityRef(int entityId)
		{
			_entityId = entityId;
		}

		public Type EntityType
		{
			get { return typeof(TEntity); }
		}

		public int EntityId
		{
			get { return _entityId; }
		}

		object IEntityRef.EntityId
		{
			get { return _entityId; }
		}

		public int CompareTo(EntityRef<TEntity> other)
		{
			return EntityId.CompareTo(other.EntityId);
		}

		public bool Equals(EntityRef<TEntity> other)
		{
			if (ReferenceEquals(other, null))
				return false;

			if (ReferenceEquals(other, this))
				return true;

			return EntityId.Equals(other.EntityId);
		}

		public override bool Equals(object other)
		{
			return Equals(other as EntityRef<TEntity>);
		}

		public override int GetHashCode()
		{
			return _entityId.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("EntityRef<{0}>({1})", typeof(TEntity).Name, EntityId);
		}
	}
}

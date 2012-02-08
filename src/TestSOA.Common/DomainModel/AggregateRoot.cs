namespace TestSOA.DomainModel
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Diagnostics.Contracts;
	using TestSOA.Messaging;
	using TestSOA.Utilities;

	public abstract class AggregateRoot<TEntity> : Entity<TEntity>, IAggregateRoot
		where TEntity : AggregateRoot<TEntity>
	{
		private readonly List<IEvent> _changes = new List<IEvent>();

		public override IAggregateRoot Root
		{
			get { return this; }
		}

		public ReadOnlyCollection<IEvent> GetUncommittedChanges()
		{
			return _changes.AsReadOnly();
		}

		public void MarkChangesAsCommitted()
		{
			_changes.Clear();
		}

		public void LoadsFromHistory(IEnumerable<IEvent> events)
		{
			Contract.Requires<ArgumentNullException>(events != null, "events");

			foreach (var @event in events)
			{
				ApplyChange(@event, false);
			}
		}

		protected void ApplyChange(IEvent @event)
		{
			Contract.Requires<ArgumentNullException>(@event != null, "event");

			ApplyChange(@event, true);
		}

		private void ApplyChange(IEvent @event, bool isNew)
		{
			this.AsDynamic().Apply(@event);

			if (isNew)
			{
				_changes.Add(@event);
			}
		}
	}
}

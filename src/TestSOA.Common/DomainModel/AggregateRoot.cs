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
		private readonly List<Event> _changes = new List<Event>();

		public override IAggregateRoot Root
		{
			get { return this; }
		}

		internal ReadOnlyCollection<Event> GetUncommittedChanges()
		{
			return _changes.AsReadOnly();
		}

		internal void MarkChangesAsCommitted()
		{
			_changes.Clear();
		}

		internal void LoadsFromHistory(IEnumerable<Event> events)
		{
			Contract.Requires<ArgumentNullException>(events != null, "events");

			foreach (var @event in events)
			{
				ApplyChange(@event, false);
			}
		}

		protected void ApplyChange(Event @event)
		{
			Contract.Requires<ArgumentNullException>(@event != null, "event");

			ApplyChange(@event, true);
		}

		private void ApplyChange(Event @event, bool isNew)
		{
			this.AsDynamic().Apply(@event);

			if (isNew)
			{
				_changes.Add(@event);
			}
		}
	}
}

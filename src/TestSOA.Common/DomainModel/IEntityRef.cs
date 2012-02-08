namespace TestSOA.DomainModel
{
	using System;
	using TestSOA.Annotations;

	public interface IEntityRef
	{
		[NotNull]
		Type EntityType { get; }

		[NotNull]
		object EntityId { get; }
	}
}

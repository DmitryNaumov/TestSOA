namespace TestSOA.ReferenceData.DomainModel
{
	using TestSOA.Annotations;
	using TestSOA.DomainModel;

	public sealed class Security : AggregateRoot<Security>
	{
		[NotNull]
		public static EntityRef<Security> Ref(int securityId)
		{
			return new EntityRef<Security>(securityId);
		}
	}
}

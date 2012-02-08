namespace TestSOA.Annotations
{
	using System;

	[AttributeUsage(AttributeTargets.Parameter)]
	public sealed class AspMvcAreaAttribute : PathReferenceAttribute
	{
		[UsedImplicitly]
		public AspMvcAreaAttribute()
		{
		}

		public AspMvcAreaAttribute(string anonymousProperty)
		{
			AnonymousProperty = anonymousProperty;
		}

		[UsedImplicitly]
		public string AnonymousProperty { get; private set; }
	}
}

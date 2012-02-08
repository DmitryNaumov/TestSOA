namespace TestSOA.Annotations
{
	using System;

	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method)]
	public sealed class AspMvcActionAttribute : Attribute
	{
		public AspMvcActionAttribute()
		{
		}

		public AspMvcActionAttribute(string anonymousProperty)
		{
			AnonymousProperty = anonymousProperty;
		}

		[UsedImplicitly]
		public string AnonymousProperty { get; private set; }
	}
}

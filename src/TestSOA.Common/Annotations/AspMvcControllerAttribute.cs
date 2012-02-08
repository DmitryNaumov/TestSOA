namespace TestSOA.Annotations
{
	using System;

	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method)]
	public sealed class AspMvcControllerAttribute : Attribute
	{
		public AspMvcControllerAttribute()
		{
		}

		public AspMvcControllerAttribute(string anonymousProperty)
		{
			AnonymousProperty = anonymousProperty;
		}

		[UsedImplicitly]
		public string AnonymousProperty { get; private set; }
	}
}

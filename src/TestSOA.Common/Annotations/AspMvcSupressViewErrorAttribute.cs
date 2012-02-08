namespace TestSOA.Annotations
{
	using System;

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public sealed class AspMvcSupressViewErrorAttribute : Attribute
	{
	}
}

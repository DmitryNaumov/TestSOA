namespace TestSOA.Annotations
{
	using System;

	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method)]
	public sealed class AspMvcViewAttribute : PathReferenceAttribute
	{
	}
}

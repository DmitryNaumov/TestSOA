namespace TestSOA.Annotations
{
	using System;

	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method, Inherited = true)]
	public sealed class RazorSectionAttribute : Attribute
	{
	}
}

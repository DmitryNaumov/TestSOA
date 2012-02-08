namespace TestSOA.Annotations
{
	using System;

	/// <summary>
	/// Indicates that method doesn't contain observable side effects.
	/// The same as <see cref="System.Diagnostics.Contracts.PureAttribute"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, Inherited = true)]
	public sealed class PureAttribute : Attribute
	{
	}
}

namespace TestSOA.ComponentModel
{
	using System;

	[AttributeUsage(AttributeTargets.Class)]
	public sealed class ComponentLifetimeAttribute : Attribute
	{
		private readonly ComponentLifetimeScope _lifetimeScope;

		public ComponentLifetimeAttribute(ComponentLifetimeScope lifetimeScope)
		{
			_lifetimeScope = lifetimeScope;
		}

		public ComponentLifetimeScope LifetimeScope
		{
			get
			{
				return _lifetimeScope;
			}
		}
	}
}

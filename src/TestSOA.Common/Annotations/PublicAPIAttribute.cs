namespace TestSOA.Annotations
{
	using System;

	/// <summary>
	/// This attribute is intended to mark publicly available API which should not be removed and so is treated as used.
	/// </summary>
	[MeansImplicitUse]
	public sealed class PublicAPIAttribute : Attribute
	{
		public PublicAPIAttribute()
		{
		}

		// ReSharper disable UnusedParameter.Local
		public PublicAPIAttribute(string comment)
		{
		}
		// ReSharper restore UnusedParameter.Local
	}
}

namespace TestSOA.DataAccess
{
	using System;

	public interface IUnitOfWork : IDisposable
	{
		void Commit();
	}
}

namespace TestSOA.PortfolioManagement.Services
{
	using TestSOA.Messaging;
	using TestSOA.PortfolioManagement.Messages;

	internal sealed class CommandHandlers : IHandleMessages<CalculateDirtyPnlRequest>
	{
		public void Handle(CalculateDirtyPnlRequest request)
		{
		}
	}
}

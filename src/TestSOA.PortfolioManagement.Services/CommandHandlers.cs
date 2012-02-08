namespace TestSOA.PortfolioManagement.Services
{
	using TestSOA.Messaging;
	using TestSOA.PortfolioManagement.Messages;

	internal sealed class CommandHandlers : IHandleMessages<CalculateDirtyPnlCommand>
	{
		public void Handle(CalculateDirtyPnlCommand request)
		{
		}
	}
}

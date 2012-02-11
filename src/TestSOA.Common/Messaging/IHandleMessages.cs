namespace TestSOA.Messaging
{
	using TestSOA.Annotations;

	public interface IHandleMessages<in T> where T : Message
	{
		void Handle([NotNull] T message);
	}
}

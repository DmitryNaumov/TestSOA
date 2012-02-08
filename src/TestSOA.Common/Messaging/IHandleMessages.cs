namespace TestSOA.Messaging
{
	using TestSOA.Annotations;

	public interface IHandleMessages<in T>
	{
		void Handle([NotNull] T message);
	}
}

namespace InjectedLearning
{
    public interface IServiceFactory
    {
        T GetService<T>() where T : class;
    }
}
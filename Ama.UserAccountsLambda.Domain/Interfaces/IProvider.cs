namespace Ama.UserAccountsLambda.Domain.Interfaces
{
    public interface IProvider<TProvider>
        where TProvider : class
    {
        object GetConnection();
        object GetConnection(params object[] parameters);
    }
}

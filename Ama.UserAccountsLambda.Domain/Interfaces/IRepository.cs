namespace Ama.UserAccountsLambda.Domain.Interfaces
{
    public interface IRepository<TProvider,TEntity>
        where TProvider : class
        where TEntity : class
    {
    }
}

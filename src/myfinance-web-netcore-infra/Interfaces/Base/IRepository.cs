
namespace myfinance_web_netcore_infra.Interfaces.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Post(TEntity entity);
        void Delete(int Id);
        List<TEntity> Get();
        TEntity Get(int Id);
    }
}

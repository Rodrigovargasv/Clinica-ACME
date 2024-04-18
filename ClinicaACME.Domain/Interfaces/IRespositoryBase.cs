
namespace ClinicaACME.Domain.Interfaces
{
    public interface IRespositoryBase<TEntity>
    {
        Task<TEntity> Create(TEntity entity);
        Task<int> Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll(TEntity entity);
        Task<TEntity> GetByName(string name);
        Task<int> Delete(TEntity entity);
    }
}

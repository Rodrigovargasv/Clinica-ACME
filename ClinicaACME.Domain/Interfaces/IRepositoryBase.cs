
namespace ClinicaACME.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        Task Create(TEntity entity);
        void Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetByName(string name);
        void Delete(TEntity entity);
    }
}

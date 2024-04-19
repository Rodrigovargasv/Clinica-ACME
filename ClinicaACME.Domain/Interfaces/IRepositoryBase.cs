
namespace ClinicaACME.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        Task Create(TEntity entity);
        void Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll(int page, int pageSize, string name);
        Task<TEntity> GetById(int id);
        void Delete(TEntity entity);
    }
}

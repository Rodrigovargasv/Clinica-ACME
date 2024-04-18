
namespace ClinicaACME.Domain.Interfaces
{
    public interface IRespositoryBase<TEntity>
    {
        Task Create(TEntity entity);
        void Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetByName(string name);
        void Delete(TEntity entity);
    }
}

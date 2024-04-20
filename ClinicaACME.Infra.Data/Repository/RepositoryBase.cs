
using ClinicaACME.Domain.Interfaces;
using ClinicaACME.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ClinicaACME.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return await _dbContext.Set<TEntity>()
                    .AsNoTracking()
                    .Where(e => EF.Property<string>(e, "Name") == name || EF.Property<string>(e, "Name").Contains(name))
                    .ToListAsync();
            }

            return await _dbContext.Set<TEntity>().AsNoTracking()
             
                    .ToListAsync();
        }
        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}


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

        public async Task<IEnumerable<TEntity>> GetAll(int page, int pageSize, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return await _dbContext.Set<TEntity>()
                    .AsNoTracking()
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Where(e => EF.Property<string>(e, "Name") == name)
                    .ToListAsync();
            }

            return await _dbContext.Set<TEntity>().AsNoTracking()
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
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

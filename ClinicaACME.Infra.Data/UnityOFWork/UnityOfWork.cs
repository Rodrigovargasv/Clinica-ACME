
using ClinicaACME.Domain.Interfaces;
using ClinicaACME.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ClinicaACME.Infra.Data.UnityOFWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnityOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Commit()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public void Rollback()
        {
           // não faça nada.
        }
    }
}

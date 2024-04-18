
using ClinicaACME.Domain.Entities;
using ClinicaACME.Domain.Interfaces;
using ClinicaACME.Infra.Data.Context;

namespace ClinicaACME.Infra.Data.Repository
{
    public class RepositoryPatient : RepositoryBase<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RepositoryPatient(ApplicationDbContext dbContext) : base(dbContext) { }

    }
}

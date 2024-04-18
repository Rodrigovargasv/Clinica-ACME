
namespace ClinicaACME.Domain.Interfaces
{
    public interface IUnityOfWork
    {
        Task<bool> Commit();
        void Rollback();
    }
}

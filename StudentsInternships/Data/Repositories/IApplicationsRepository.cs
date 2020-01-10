using StudentsInternships.Data.Entities;
using System.Threading.Tasks;

namespace StudentsInternships.Data.Repositories
{
    public interface IApplicationsRepository
    {
        void Add<Application>(Application application);
        Task<Application[]> GetAllApplicationsAsync();
        Task<bool> SaveChangesAsync();
        Task<Application[]> GetAppsById(int userId,string userType);
        Task<Application> ApplyToInternship(Application app);
        Task<Application> ChangeAppStatus(Application app);
    }
}

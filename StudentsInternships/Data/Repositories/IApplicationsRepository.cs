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
        Task<Application> ChangeAppStatus(Application app);
        Task<bool> DeleteApp(int id);
        Task<int > ApplyToInternship(int studentId, int internshipId);
        Task<Application> GetAppById(int result);
    }
}

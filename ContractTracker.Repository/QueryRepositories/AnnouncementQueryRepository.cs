using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.QueryRepositories
{
    public interface IAnnouncementQueryRepository
    {
        Task<List<Announcements>> GetAnnouncements();
    }
    public class AnnouncementQueryRepository : IAnnouncementQueryRepository
    {
        private readonly TrackerDbContext context;
        public AnnouncementQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<List<Announcements>> GetAnnouncements()
        {
            try
            {
                var entities = await context.Announcements.ToListAsync();
                return entities;
            }
            catch(Exception ex)
            {
                string wtf = ex.ToString();
            }
            return null;
            
        }
    }
}

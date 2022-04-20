using ContractTracker.Repository.QueryRepositories;
using ContractTracker.Services.Business.Models;

namespace ContractTracker.Services.Business.Services
{
    public interface IAnnouncementService
    {
        Task<List<AnnouncementResponseModel>> GetAllAnnoucements();
    }
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementQueryRepository announcementQueryRepository;
        public AnnouncementService(IAnnouncementQueryRepository announcementQueryRepository)
        {
            this.announcementQueryRepository = announcementQueryRepository;
        }

        public async Task<List<AnnouncementResponseModel>> GetAllAnnoucements()
        {
            var allEntities = await announcementQueryRepository.GetAnnouncements();
            return allEntities.ConvertAll(x => Mappers.AnnouncementMapper.MapEntityToModel(x));
        }
    }
}

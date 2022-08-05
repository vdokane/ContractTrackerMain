using ContractTracker.Services.Business.Models;
using ContractTracker.Repository.EntityModels;

namespace ContractTracker.Services.Business.Mappers
{
    internal class AnnouncementMapper
    {
        public static AnnouncementResponseModel? MapEntityToModel(Announcements entity)
        {
            if (entity == null)
                return null;
            
            var model = new AnnouncementResponseModel();
            model.AnnouncementId = entity.AnnouncementId;
            model.InsertDate = entity.InsertDate;
            model.AnnouncementMessage = entity.AnnouncementMessage; 
            model.UserId = entity.UserId;
            return model;
        }
    }
}

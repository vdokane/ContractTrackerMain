namespace ContractTracker.Services.Business.Models
{
    public class AnnouncementResponseModel
    {
        public int AnnouncementId { get; set; }
        public string? AnnouncementMessage { get; set; }
        public int UserId { get; set; }
        public DateTime InsertDate { get; set; }
    }
}

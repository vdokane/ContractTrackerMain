namespace ContractTracker.Services.Business.Models.Shared
{
    public abstract class SearchResponseBaseModel
    {
        public int TotalRows { get; set; }
        public int CurrentPageNumber { get; set; }
    }
}

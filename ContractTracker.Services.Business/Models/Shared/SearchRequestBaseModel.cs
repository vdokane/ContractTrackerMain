namespace ContractTracker.Services.Business.Models.Shared
{
    public abstract class SearchRequestBaseModel
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string SortColumn { get; set; } = string.Empty;
        public string SortDirection { get; set; } = string.Empty;

    }
}

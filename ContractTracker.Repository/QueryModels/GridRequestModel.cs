namespace ContractTracker.Repository.QueryModels
{
    public abstract class GridRequestModel
    {
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public string SortColumn { get; set; } = string.Empty;
        public string SortDirection { get; set; } = string.Empty;
    }
}

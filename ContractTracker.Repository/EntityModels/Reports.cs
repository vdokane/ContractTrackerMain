using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class Reports
    {
        [Key]
        public int ReportId { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string DrillThruValue { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Stop { get; set; }
        public string ProcName { get; set; }
        public string ReportType { get; set; }
        public bool ReadOnlyAccess { get; set; }
        public string BreakTabOn { get; set; }
        public string CategoryAxis { get; set; }
        public string ValueAxis { get; set; }
        public bool ShowDateRange { get; set; }
        public int WaitSecs { get; set; }
        public string OptionalFilter { get; set; }
    }
}

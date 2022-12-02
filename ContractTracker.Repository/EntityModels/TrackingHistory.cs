using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class TrackingHistory
    {
        [Key]
        public int TrackingHistoryId { get; set; }
        public int ContractId { get; set; }
        public int TrackingStepId { get; set; }
        public int? AmmendmentId { get; set; }
        public string Message { get; set; } = string.Empty;
        public int UserId { get; set; } //this should be renamed to CreatedByUserId
        public DateTime InsertDate { get; set; } //this should be renamed to CreatedDate
    }
}

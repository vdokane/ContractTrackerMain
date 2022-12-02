using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class Deliverables
    {
        [Key]
        public int DeliverableId { get; set; }
        public int ContractId { get; set; }
        public int? MethodOfPaymentId { get; set; }
        public string MajorDeliverable { get; set; } = string.Empty;
        public decimal DeliverablePrices { get; set; }
        public int? NonPriceJustification { get; set; }
        public string PerformanceMatrix { get; set; } = string.Empty;
        public string FinancialConsequences { get; set; } = string.Empty;
        public string DocumentationPageReference { get; set; } = string.Empty;
        public string CommodityCode { get; set; } = string.Empty;
        public bool? MarkedForDeletion { get; set; }
        public bool? Archive { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int? ContractAppDeliverableId { get; set; }


    }
}

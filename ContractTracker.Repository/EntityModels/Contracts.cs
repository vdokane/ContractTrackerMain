using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractTracker.Repository.EntityModels
{
    public class Contracts
    {
        [Key]
        public int ContractId { get; set; }
        public string ContractNumber { get; set; }
        public int? ContractTypeId { get; set; }
        public int? VendorId { get; set; }
        public int? ContractApplicationId { get; set; }
        public string FLAIRContractId { get; set; }
        public int? ProcurementMethodId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExecuteDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }
        public decimal? HourlyRate { get; set; }
        public bool? Recurring { get; set; }
        public string ServiceType { get; set; }
        public bool? AuthorizedADPayment { get; set; }
        public string StateTermContractIdentifier { get; set; }
        public string ExemptionExplanation { get; set; }
        public string ContractStatutoryAuthority { get; set; }
        public string GeneralComments { get; set; }
        public string InternalComments { get; set; }
        public bool? ContractInvolveFinancialAid { get; set; }
        public string RecipientTypeCode { get; set; }
        public bool? IndirectCostInd { get; set; }
        public string AdministrativeCostPercentage { get; set; }
        public bool? ProvidePeriodicIncrease { get; set; }
        public decimal? PeriodicIncreasePercentage { get; set; }
        public bool? BusinessCaseStudyDone { get; set; }
        public DateTime? BusinessCaseDate { get; set; }
        public bool? LegalChallengesProcurement { get; set; }
        public string LegalChallengeDescription { get; set; }
        public bool? PreviouslyDoneByTheState { get; set; }
        public bool? ConsideredBackToTheState { get; set; }
        public bool? CapitalImprovementsOnStateProperty { get; set; }
        public string CapitalImprovementDescription { get; set; }
        public decimal? ValueCapitalImprovements { get; set; }
        public decimal? ValueUnamortizedCapitalImprovements { get; set; }
        public string CSFA { get; set; }
        public string CFDA { get; set; }
        public string ContractStatus { get; set; }
        public string RejectionMessage { get; set; }
        public string SweepStatus { get; set; }
        public bool? ExistingContract { get; set; }
        public DateTime? ExportDate { get; set; }
        public bool? MarkedForDeletion { get; set; }
        public bool? Confidential { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int? PublicContractAppContractId { get; set; }
    }
}

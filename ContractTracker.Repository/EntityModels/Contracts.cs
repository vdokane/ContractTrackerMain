using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractTracker.Repository.EntityModels
{
    public class Contracts
    {
        [Key]
        public int ContractId { get; set; }
        public int? ContractTypeId { get; set; }
        public int? VendorId { get; set; }
        public int? ContractApplicationId { get; set; }
        public string ContractNumber { get; set; } = string.Empty;
        public string FLAIRContractId { get; set; } = string.Empty;
        public int? ProcurementMethodId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExecuteDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }
        public decimal? HourlyRate { get; set; }
        public bool? Recurring { get; set; }
        public string ServiceType { get; set; } = string.Empty;
        public bool? AuthorizedADPayment { get; set; }
        public string StateTermContractIdentifier { get; set; } = string.Empty;
        public string ExemptionExplanation { get; set; } = string.Empty;
        public string ContractStatutoryAuthority { get; set; } = string.Empty;
        public string GeneralComments { get; set; } = string.Empty;
        public string InternalComments { get; set; } = string.Empty;
        public bool? ContractInvolveFinancialAid { get; set; }
        public string RecipientTypeCode { get; set; } = string.Empty;
        public bool? IndirectCostInd { get; set; }
        public string AdministrativeCostPercentage { get; set; } = string.Empty;
        public bool? ProvidePeriodicIncrease { get; set; }
        public decimal? PeriodicIncreasePercentage { get; set; }
        public bool? BusinessCaseStudyDone { get; set; }
        public DateTime? BusinessCaseDate { get; set; }
        public bool? LegalChallengesProcurement { get; set; }
        public string LegalChallengeDescription { get; set; } = string.Empty;
        public bool? PreviouslyDoneByTheState { get; set; }
        public bool? ConsideredBackToTheState { get; set; }
        public bool? CapitalImprovementsOnStateProperty { get; set; }
        public string CapitalImprovementDescription { get; set; } = string.Empty;
        public decimal? ValueCapitalImprovements { get; set; }
        public decimal? ValueUnamortizedCapitalImprovements { get; set; }
        public string CSFA { get; set; } = string.Empty;
        public string CFDA { get; set; } = string.Empty;
        public string ContractStatus { get; set; } = string.Empty;
        public string RejectionMessage { get; set; } = string.Empty;
        public string SweepStatus { get; set; } = string.Empty;
        public bool? ExistingContract { get; set; }
        public DateTime? ExportDate { get; set; }
        public bool? MarkedForDeletion { get; set; }
        public bool? Confidential { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int? PublicContractAppContractId { get; set; }  //what was this for? 
    }
}

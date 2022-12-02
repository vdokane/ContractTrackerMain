using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class TrackingSteps
    {
        [Key]
        public int TrackingStepId { get; set; }
        public string StepDescription { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}

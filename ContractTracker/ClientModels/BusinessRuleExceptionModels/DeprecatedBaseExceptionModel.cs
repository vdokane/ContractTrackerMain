using ContractTracker.Common.Infrastructure;

namespace ContractTracker.ClientModels.BusinessRuleExceptionModels
{
    public abstract class DeprecatedBaseExceptionModel
    {
        public bool IsBusinessException { get; set; }
        public List<ValidationMessage> Messages { get; set; } = new List<ValidationMessage>();
    }
}

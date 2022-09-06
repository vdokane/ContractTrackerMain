using ContractTracker.Common.Infrastructure;

namespace ContractTracker.Common.ClientAndServerModels.Exception
{
    public abstract class BaseResponseModel
    {
        public bool IsBusinessException { get; set; } = false;
        public List<ValidationMessage> ExceptionMessages { get; set; } = new List<ValidationMessage>();
        public List<string> SucessMessages { get; set; } = new List<string>();

    }
}

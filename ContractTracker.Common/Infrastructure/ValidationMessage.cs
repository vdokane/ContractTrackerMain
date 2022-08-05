namespace ContractTracker.Common.Infrastructure
{

    public class ValidationMessage
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public ValidationMessage()
        {
        }

        public ValidationMessage(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }

}

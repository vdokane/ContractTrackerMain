namespace ContractTracker.Common.Infrastructure
{
    public class BusinessRuleException<T> : Exception
    {
        public List<T> ValidationMessages { get; private set; }

        public BusinessRuleException(params T[] validationMessages)
        {
            ValidationMessages = validationMessages.ToList();
        }

        public BusinessRuleException(IEnumerable<T> validationMessages)
        {
            ValidationMessages = validationMessages.ToList();
        }
    }

    public class BusinessRuleException : BusinessRuleException<ValidationMessage>
    {
        public BusinessRuleException(params ValidationMessage[] validationMessages) : base(validationMessages)
        {
        }

        public BusinessRuleException(IEnumerable<ValidationMessage> validationMessages)
            : base(validationMessages)
        {
        }
    }
}

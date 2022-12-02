using ContractTracker.Repository.EntityModels;

namespace ContractTracker.Repository.Interfaces
{
    public interface IContractAttachmentQueryRepository
    {
        Task<ContractAttachments> GetAttachmentById(int contractAttachmentId);
    
    }
}

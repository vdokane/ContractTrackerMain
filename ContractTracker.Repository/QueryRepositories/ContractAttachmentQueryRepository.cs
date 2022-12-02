using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
 

namespace ContractTracker.Repository.QueryRepositories
{
    public class ContractAttachmentQueryRepository : IContractAttachmentQueryRepository
    {
        private readonly TrackerDbContext context;

        public ContractAttachmentQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<ContractAttachments> GetAttachmentById(int contractAttachmentId)
        {
            return await context.ContractAttachments.Where(x => x.ContractAttachmentId == contractAttachmentId).FirstOrDefaultAsync();
        }
    }
}

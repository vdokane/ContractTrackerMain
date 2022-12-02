using ContractTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractTracker.Services.Business.Services
{
    public interface IContractAttachmentService
    {

    }
    public class ContractAttachmentService : IContractAttachmentService
    {
        private readonly IContractAttachmentQueryRepository contractDocumentQueryRepository;
        public ContractAttachmentService(IContractAttachmentQueryRepository contractDocumentQueryRepository)
        {
            this.contractDocumentQueryRepository = contractDocumentQueryRepository;
        }
    }
}

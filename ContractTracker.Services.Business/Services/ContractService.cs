using ContractTracker.Repository.QueryRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractTracker.Services.Business.Services
{
    public interface IContractService
    {

    }
    public class ContractService : IContractService
    {
        public ICaseQueryRepository caseQueryRepository;

        public ContractService(ICaseQueryRepository caseQueryRepository)
        {
            this.caseQueryRepository = caseQueryRepository;
        }
    }
}

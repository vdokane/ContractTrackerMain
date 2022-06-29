using ContractTracker.Repository.Interfaces;
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
        public IContractQueryRepository contractQueryRepository;

        public ContractService(IContractQueryRepository contractQueryRepository)
        {
            this.contractQueryRepository = contractQueryRepository;
        }
    }
}

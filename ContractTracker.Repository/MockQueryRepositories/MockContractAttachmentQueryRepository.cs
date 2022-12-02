using ContractTracker.Repository.DocumentHelpers;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;

namespace ContractTracker.Repository.MockQueryRepositories
{
    public class MockContractAttachmentQueryRepository : IContractAttachmentQueryRepository
    {
        //TODO, inject in DocumentHelper? Maybe? 
        private readonly FileSystemRepository fileSystemRepository;
        private const string pathToGenericFileOnDisk = "C:todo"; //This should be more like file name
        public MockContractAttachmentQueryRepository(FileSystemRepository fileSystemRepository)
        {
            this.fileSystemRepository = fileSystemRepository;
        }

        public async Task<ContractAttachments> GetAttachmentById(int contractAttachmentId)
        {
            //Need to inject in a location to save files to. 
            var rootDir = System.Reflection.Assembly.GetExecutingAssembly();
            var tst = Path.GetDirectoryName(rootDir.Location);

            var mockEntity = new ContractAttachments();
            mockEntity.ContractAttachmentId = contractAttachmentId;

            var document = fileSystemRepository.GetFile(pathToGenericFileOnDisk);
            if (document == null)
                return mockEntity;

            mockEntity.Attachment = document;
            mockEntity.AttachmentTypeId = 1;
            mockEntity.FileName = "mockfile.txt";

            return await Task.FromResult(mockEntity);

        }
    }
}

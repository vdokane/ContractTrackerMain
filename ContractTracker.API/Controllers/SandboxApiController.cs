using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using ContractTracker.Common.ClientAndServerModels.User;
using ContractTracker.API.Services;
using ContractTracker.Common.Infrastructure;
using ContractTracker.Common.ClientAndServerModels.Document;
using ContractTracker.Services.Business.Models.FileUploadModels;

namespace ContractTracker.API.Controllers
{
    [Route("api/sandbox")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SandboxApiController : BaseApiController
    {
        private readonly ISignedInUserService signedInUserServiceAccessor;
        public SandboxApiController(ISignedInUserService signedInUserServiceAccessor)
        {
            this.signedInUserServiceAccessor = signedInUserServiceAccessor;
            //TODO https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/dependency-injection
        }


        [HttpGet("getnow")]
        public DateTime GetNow()
        {
            var now = DateTime.UtcNow;
            return now;
        }

        [HttpGet("getcomplexmodel")]
        public UserResponseModel GetComplexModel()
        {
            return new UserResponseModel() { Role = "sandbox", UserId = 999, UserName = "Demo Sandbox", UserUnitIds = new List<int>() { 1, 2, 34 } };
        }

        [HttpGet("getcomplexmodelwithparams")]
        public UserResponseModel GetComplexModelWithParams(int userId, string userName)
        {
            return new UserResponseModel() { Role = "sandbox", UserId = userId, UserName = userName, UserUnitIds = new List<int>() { 1, 2, 34 } };
        }

        [HttpPost("insertuser")]
        public UserResponseModel CreateUser([FromBody] UserInsertRequestModel requestModel)
        {
            var currentUserName = ThisShouldBeaService_GetCurrentUserAccountName();
            var shouldBeCurrentUserName3 = signedInUserServiceAccessor.GetCurrentUserAccountName();
            var mutatedData = requestModel.UnitId + 1;
            return new UserResponseModel() { Role = "sandbox", UserId = 777, UserName = requestModel.UserName, UserUnitIds = new List<int>() { mutatedData } };

        }

        [HttpPost("insertuserauthorized")]
        public UserResponseModel CreateUserAuthorized([FromBody] UserInsertRequestModel requestModel)
        {
            var currentUserName = ThisShouldBeaService_GetCurrentUserAccountName();
            var mutatedData = requestModel.UnitId + 1;
            return new UserResponseModel() { Role = "sandbox", UserId = 777, UserName = requestModel.UserName, UserUnitIds = new List<int>() { mutatedData } };

        }

        [HttpPost("kaboom")]
        public UserResponseModel Kaboom()
        {
            throw new Exception("Kaboom");
            return new UserResponseModel() { Role = "sandbox", UserId = 777, UserName = "Kaboom.User", UserUnitIds = new List<int>() { 1, 2, 3 } };
        }

        [HttpGet("businessruleexception")]
        [AllowAnonymous] //Make sure to remove this before production!!! 
        public void BusinessRuleException()
        {
            var validationMessages = new ValidationMessage[] { new ValidationMessage("99", "messag1"), new ValidationMessage("98", "message2") };
            throw new BusinessRuleException(validationMessages);
        }

        [HttpPost("documentupload")]
        [ValidateAntiForgeryToken]
        public async Task<DocumentApiResponseModel> DocumentUpload(IFormFile formFile)
        {

            //Need to inject in a location to save files to. 
            var rootDir = System.Reflection.Assembly.GetExecutingAssembly();
            var tst = Path.GetDirectoryName(rootDir.Location);

            var attachment = new UploadedDocumentRequestModel();
            attachment.FileName = formFile.FileName;
            attachment.GeneratedFileName = Path.GetRandomFileName();
            attachment.FileContentType = formFile.ContentType;

            using (var ms = new MemoryStream())
            {
                await formFile.CopyToAsync(ms);
                ms.Seek(0, SeekOrigin.Begin);
                attachment.FileContent = ms.ToArray();
            }


            return new DocumentApiResponseModel() { ContractDocumentId = -1, IsBusinessException = false };
        }

        #region private methods

        private string? ThisShouldBeaService_GetCurrentUserAccountName()
        {
            if (HttpContext.User == null)
                return null;

            var shouldBeName = HttpContext.User.Identity.Name;
            return shouldBeName;

        }
        #endregion

    }
}

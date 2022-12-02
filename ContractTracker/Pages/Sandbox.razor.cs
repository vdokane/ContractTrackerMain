using Microsoft.AspNetCore.Components;
using Radzen;
using ContractTracker.Services;
using ContractTracker.Common.ClientAndServerModels.User;
using ContractTracker.Common.ClientAndServerModels.Exception;
using Tewr.Blazor.FileReader;
using System.Net.Http.Headers;
using ContractTracker.ClientModels.DocumentUploadModels;
using Microsoft.JSInterop;

namespace ContractTracker.Pages
{
    public class SandboxComponentBase : ComponentBase
    {
        [Inject]
        public ISandboxService sandboxService { get; set; } = null!;
        [Inject]
        public ILogginService logginService { get; set; } = null!;

        [Inject]
        public ILoggerFactory LoggerFactory { get; set; } = null!;

        [Inject]
        public NotificationService NotificationService { get; set; } = null!;

        [Inject]
        public IFileReaderService fileReaderService { get; set; } = null!;
        
        [Inject]
        public IJSRuntime JS { get; set; } = null!;

        [Inject]
        public NavigationManager navManager { get; set; } = default!;

        protected ElementReference inputReference;
        protected string message = string.Empty;
        protected string fileName = string.Empty;
        protected string type = string.Empty;
        protected string size = string.Empty;
        protected Stream fileStream = null!;
        
        protected ElementReference inputReferenceComplex;
        protected string fileName2 = string.Empty;
        protected string type2 = string.Empty;
        protected string size2 = string.Empty;
        protected Stream fileStream2 = null!;


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected async Task GetComplexModel()
        {
            var model = await sandboxService.GetUserResponseModelNoParams();
        }

        protected async Task GetComplexModelWithParams()
        {
            var responseModel = await sandboxService.GetComplexModelWithParams(7832, "UserNanme From Component");
            HandleResponseNotification(responseModel);
        }

        protected async Task PostObject()
        {
            var requestModel = new UserInsertRequestModel() { UserRoleId = 22, UserName = "fromComponent", UnitId = 44, FirstName = "fnmae", LastName = "lname", StartDate = DateTime.Now };
            var responseModel = await sandboxService.PostExample(requestModel);
            HandleResponseNotification(responseModel);
        }



        #region Kaboom
        protected async Task InvokeKaboom()
        {
            //So how do I capture the response? And tell the difference between a regular exception and a business rule exception?
            var responseModel = await sandboxService.InvokeKaboom();
        }

        protected async Task InvokeBusinessRuleKaboom()
        {
            //by keeping the try catch at the service level this will bind all response models to know what a business error is
            //ok, so having it as a base class works dandy, so now every service method should just check the flag and push it back to the UI if errors
            var responseModel = await sandboxService.InvokeBusinessRuleKaboom();

            //TODO all components should be able to handle this the same
            HandleResponseNotification(responseModel);

        }

        protected async Task ClientKaboom()
        {
            var logger = LoggerFactory.CreateLogger<Sandbox>();
            
            try
            {
                throw new Exception("Kaboom!");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                await logginService.SaveClientError(navManager.Uri, ex);
            }
        }
        #endregion

        #region private methods

        private void HandleResponseNotification(BaseResponseModel baseResponse)
        {
            if (baseResponse == null)
                return; //TODO actually this should be a generic error message or somethign like"your request could not be processed at this time

            var notificationMessage = new NotificationMessage();
            notificationMessage.Duration = 40000;
            //notificationMessage.Style = "position: absolute; left: -1000px;"; TODO

            if (baseResponse.IsBusinessException)
            {

                notificationMessage.Severity = NotificationSeverity.Error;
                notificationMessage.Summary = "FAIL Summary";
                notificationMessage.Detail = "FAIL Detail";

            }
            else
            {
                notificationMessage.Severity = NotificationSeverity.Success;
                notificationMessage.Summary = "PASS Summary";
                notificationMessage.Detail = "PASS Detail";

            }
            NotificationService.Notify(notificationMessage);
        }
        #endregion

        #region document upload
        protected async Task UploadFile()
        {
            if (fileStream == null)
                return;

            var content = new MultipartFormDataContent();

            bool responsePass = true;
            using (var streamContent = new StreamContent(fileStream, (int)fileStream.Length))
            {
                using (var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync()))
                {
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "formFile", // "formFile" parameter name should be the same as the server side input parameter name
                        FileName = fileName
                    };
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(type);
                    content.Add(fileContent);
                    responsePass = await sandboxService.DocumentUploadExample(content);
                }
            }

            if (responsePass)
                Console.WriteLine("Was success");
            else
                Console.WriteLine("IT ERRORED");


            fileName = string.Empty;
            type = string.Empty;
            size = string.Empty;
            var fileThatWasSelected = fileReaderService.CreateReference(inputReference);
            await fileThatWasSelected.ClearValue();
        }

        protected async Task OpenFile()
        {
            var file = (await fileReaderService.CreateReference(inputReference).EnumerateFilesAsync()).FirstOrDefault();
            if (file == null)
            {
                return;
            }

            var fileInfo = await file.ReadFileInfoAsync();
            fileName = fileInfo.Name;
            type = fileInfo.Type;
            size = $"{fileInfo.Size} Bytes";

            using (var ms = await file.CreateMemoryStreamAsync((int)fileInfo.Size))
            {
                fileStream = new MemoryStream(ms.ToArray());
            }
        }

        protected async Task OpenFile2()
        {
            var file = (await fileReaderService.CreateReference(inputReferenceComplex).EnumerateFilesAsync()).FirstOrDefault();
            if (file == null)
            {
                return;
            }

            var fileInfo = await file.ReadFileInfoAsync();
            fileName2 = fileInfo.Name;
            type2 = fileInfo.Type;
            size2 = $"{fileInfo.Size} Bytes";

            using (var ms = await file.CreateMemoryStreamAsync((int)fileInfo.Size))
            {
                fileStream2 = new MemoryStream(ms.ToArray());
            }
        }

        protected async Task UploadFile2()
        {
            if (fileStream2 == null)
                return;


            //TODO 10/20
            var request = new ContractDocumentApiRequestModel();
            request.ContractDocumentTypeId = 14;
            request.ContractId = 34;
            request.FileName = fileName2;
            request.ContractDocumentFormFile = fileStream2;

            bool responsePass = true;
            responsePass = await sandboxService.ComplexDocumentUploadExample(request);
          
          
            if (responsePass)
                Console.WriteLine("Was success");
            else
                Console.WriteLine("IT ERRORED");

 
        }

        #endregion

        #region document download 
        /* this did NOT work
        protected async Task GetContractAttachment()
        {
            var stream = await sandboxService.GetContractAttachmentById(99);
            //using var streamRef = DotNetStreamReference(stream: fileStream);

            await JS.InvokeVoidAsync("downloadFileFromStream", "test.txt", stream);
        } */
        #endregion
    }


}

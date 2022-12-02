using ContractTracker.Common.ClientAndServerModels.User;
using Newtonsoft.Json;
using ContractTracker.Infrastructure;
using Blazored.LocalStorage;
using System.Text;
using System.Net;
using ContractTracker.ClientModels.DocumentUploadModels;

namespace ContractTracker.Services
{
    public interface ISandboxService
    {
        Task<UserResponseModel?> GetUserResponseModelNoParams();
        Task<UserResponseModel?> GetComplexModelWithParams(int userId, string userName);
        Task<UserResponseModel> PostExample(UserInsertRequestModel userInsertRequestModel);
        Task<UserResponseModel> InvokeKaboom();
        Task<UserResponseModel> InvokeBusinessRuleKaboom();
        Task<bool> DocumentUploadExample(MultipartFormDataContent content);
        Task<bool> ComplexDocumentUploadExample(ContractDocumentApiRequestModel requestModel);
        Task<Stream> GetContractAttachmentById(int contractAttachmentId);
    }
    public class SandboxService : ServiceBase, ISandboxService
    {
        
        public SandboxService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage) : base(httpClient, configuration, localStorage)
        {
        }

        public async Task<UserResponseModel?> GetUserResponseModelNoParams_THISWORKS()
        {
            try
            {
                await SetJwtAuthHeader();

                var route = baseUrlForApiSite + ServiceRoutes.Sandbox.GetComplexModelApiUrl();
                var response = await httpClient.GetStringAsync(route);

                if (string.IsNullOrEmpty(response))
                    return null;

                var responseModel = JsonConvert.DeserializeObject<UserResponseModel>(response);
                return responseModel;
            }
            catch
            {
                return null;
            }

        }
        public async Task<UserResponseModel?> GetUserResponseModelNoParams()
        {
            var route = baseUrlForApiSite + ServiceRoutes.Sandbox.GetComplexModelApiUrl();
            return await ImBaseGetMethod<UserResponseModel>(route);
        }
        public async Task<UserResponseModel?> GetComplexModelWithParams(int userId, string userName)
        {
            var route = baseUrlForApiSite + ServiceRoutes.Sandbox.GetComplexModelWithParamsApiUrl(userId, userName);
            return await ImBaseGetMethod<UserResponseModel>(route);

        }
        public async Task PostExample_THISWORKS(UserInsertRequestModel userInsertRequestModel)
        {
            var route = baseUrlForApiSite + ServiceRoutes.Sandbox.PostObjectApiUrl();
            try
            {
                await SetJwtAuthHeader();
                string serialized = Newtonsoft.Json.JsonConvert.SerializeObject(userInsertRequestModel);
                StringContent stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

                var httpResponseMessage = await httpClient.PostAsync(route, stringContent);
                var tst = await httpResponseMessage.Content.ReadAsStringAsync();
                if (tst != null)
                {
                    var userReponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<UserResponseModel>(tst);
                }
            }
            catch (Exception ex)
            {
                string dbug = ex.ToString();
                Console.WriteLine(dbug);
            }
        }

        public async Task<UserResponseModel> PostExample(UserInsertRequestModel userInsertRequestModel)
        {
            var route = baseUrlForApiSite + ServiceRoutes.Sandbox.PostObjectApiUrl();
            return await ImBasePostMethod<UserResponseModel>(route, userInsertRequestModel);
        }

        public async Task<UserResponseModel> InvokeKaboom()
        {
            var route = baseUrlForApiSite + ServiceRoutes.Sandbox.KaboomApiUrl();
            var dummy = new UserInsertRequestModel();
            return await ImBasePostMethod<UserResponseModel>(route, dummy);
        }

        public async Task<UserResponseModel> InvokeBusinessRuleKaboom()
        {
            var route = baseUrlForApiSite + ServiceRoutes.Sandbox.KaboomBusinessRuleApiUrl();
            return await ImBaseGetMethod<UserResponseModel>(route);
        }

        public async Task<bool> DocumentUploadExample(MultipartFormDataContent content)
        {
            await SetJwtAuthHeader();
            var route = baseUrlForApiSite + ServiceRoutes.Sandbox.DocumentUpload();
            var response = await httpClient.PostAsync(route, content);
            return response.IsSuccessStatusCode;
        }

        //For complex objects that include IForm, you must use SendAsync:
        //https://brokul.dev/sending-files-and-additional-data-using-httpclient-in-net-core
        public async Task<bool> ComplexDocumentUploadExample(ContractDocumentApiRequestModel requestModel)
        {
            await SetJwtAuthHeader();

            var route = baseUrlForApiSite + ServiceRoutes.Sandbox.DocumentUploadComplexObject();
            using var request = new HttpRequestMessage(HttpMethod.Post, route);
            using var content = new MultipartFormDataContent
            {
                { new StreamContent(requestModel.ContractDocumentFormFile), "ContractDocumentFormFile", requestModel.FileName },
                { new StringContent(requestModel.ContractId.ToString()), "ContractId" },
                { new StringContent(requestModel.ContractDocumentTypeId.ToString()), "ContractDocumentTypeId" },
            };
            request.Content = content;
            var anyResponse = await httpClient.SendAsync(request);
            return anyResponse.IsSuccessStatusCode;
        }

        public async Task<Stream> GetContractAttachmentById(int contractAttachmentId)
        {
            await SetJwtAuthHeader();

            var route = baseUrlForApiSite + ServiceRoutes.Sandbox.GetContractAttachmentById();
            await SetJwtAuthHeader();
            var responseTEST = await httpClient.GetAsync(route);
            var stream = responseTEST.Content.ReadAsStream(); //So how do I get the name out of this

            /* testing 
            using (StreamReader reader = new StreamReader(responseTEST.Content.ReadAsStream()))
            {
                var response = reader.ReadToEnd();
                Console.WriteLine(response);

            }  */

            return stream;
            
            
        }


        #region private methods
        private async Task<T> ImBaseGetMethod<T>(string route)
        {
            //Nope, this screws up everyting... route = Uri.EscapeDataString(route);
            //2022/08/30, weird, it catches the 400 then response is populated.. 
            string tst = string.Empty;
            try
            {
                await SetJwtAuthHeader();

                var responseTEST = await httpClient.GetAsync(route);  


                var payload = responseTEST.Content.ReadAsStream();

                if (payload == null)
                    return default;

                using (StreamReader reader = new StreamReader(payload))
                {
                    var response = reader.ReadToEnd();
                    var responseModel = JsonConvert.DeserializeObject<T>(response);
                    return responseModel;
                }
            }
            catch (System.Net.Http.HttpRequestException ex) //So how can I capture the 400?
            {
                string dbug = ex.ToString();
                var tst2 = tst;
                return default;
            }
        }


        private async Task<T> ImBasePostMethod<T>(string route, object postObject)
        {
            try
            {
                await SetJwtAuthHeader();

                string serialized = Newtonsoft.Json.JsonConvert.SerializeObject(postObject);
                StringContent stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

                var httpResponseMessage = await httpClient.PostAsync(route, stringContent);
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    if (httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var tmp = await httpResponseMessage.Content.ReadAsStringAsync();

                    }
                    return default;
                }

                var tst = await httpResponseMessage.Content.ReadAsStringAsync();
                if (tst == null)
                    return default;

                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(tst);

            }
            catch (Exception ex)
            {
                string dbug = ex.ToString();
                return default;
            }
        }

        /// <summary>
        /// this needs to be used when I get ready to handle error boundries for the app. Not processing 500 from responses
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="route"></param>
        /// <param name="postObject"></param>
        /// <returns></returns>
        private async Task<T> ImBasePostMethodWithNoCatch<T>(string route, object postObject)
        {

            await SetJwtAuthHeader();

            string serialized = Newtonsoft.Json.JsonConvert.SerializeObject(postObject);
            StringContent stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            var httpResponseMessage = await httpClient.PostAsync(route, stringContent);
            var tst = await httpResponseMessage.Content.ReadAsStringAsync();
            if (tst == null)
                return default;

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(tst);

        }

        #endregion

    }

}


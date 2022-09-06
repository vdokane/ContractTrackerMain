using ContractTracker.Common.ClientAndServerModels.User;
using Newtonsoft.Json;
using ContractTracker.Infrastructure;
using ContractTracker.Authentication;
using Blazored.LocalStorage;
using System.Text;
using System.Net;
using ContractTracker.ClientModels.BusinessRuleExceptionModels;

namespace ContractTracker.Services
{
    public interface ISandboxService
    {
        Task<UserResponseModel?> GetUserResponseModelNoParams();
        Task<UserResponseModel?> GetComplexModelWithParams(int userId, string userName);
        Task<UserResponseModel> PostExample(UserInsertRequestModel userInsertRequestModel);

        Task<UserResponseModel> InvokeKaboom();
        Task<UserResponseModel> InvokeBusinessRuleKaboom();
    }
    public class SandboxService : ISandboxService
    {
        protected readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        protected readonly string baseUrlForApiSite;
        private readonly ILocalStorageService localStorage;

        public SandboxService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            baseUrlForApiSite = configuration.GetValue<string>("BaseUrlApi");
            this.localStorage = localStorage;
        }

        public async Task<UserResponseModel?> GetUserResponseModelNoParams_THISWORKS()
        {
            try
            {
                var authConstants = new AuthConstants(configuration);
                var localStorageKey = authConstants.LocalStorageKeyForJwt;
                var jwt = await localStorage.GetItemAsync<string>(localStorageKey);

                //got to be a better way than manually setting it... damn, this will go in new base, private method here
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

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
        //abstract out the model url params and the return type for get and posts


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

        //Hm? What generic response should these return??
        public async Task PostExample_THISWORKS(UserInsertRequestModel userInsertRequestModel)
        {
            var route = baseUrlForApiSite + ServiceRoutes.Sandbox.PostObjectApiUrl();
            try
            {
                var authConstants = new AuthConstants(configuration);
                var localStorageKey = authConstants.LocalStorageKeyForJwt;
                var jwt = await localStorage.GetItemAsync<string>(localStorageKey);

                //got to be a better way than manually setting it... damn, this will go in new base, private method here
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

                string serialized = Newtonsoft.Json.JsonConvert.SerializeObject(userInsertRequestModel);
                StringContent stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

                var httpResponseMessage = await httpClient.PostAsync(route, stringContent);
                var tst = await httpResponseMessage.Content.ReadAsStringAsync();
                if (tst != null)
                {
                    //StreamReader reader = new StreamReader(tst);
                    //string text = reader.ReadToEnd();
                    var userReponseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<UserResponseModel>(tst);
                }
                //..todo get the response model out of this... 
                //httpResponseMessage. 
            }
            catch (Exception ex)
            {
                string dbug = ex.ToString();
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
            var dummy = new UserInsertRequestModel();
            return await ImBaseGetMethod<UserResponseModel>(route);
        }

        private async Task<T> ImBaseGetMethod<T>(string route)
        {
            //Nope, this screws up everyting... route = Uri.EscapeDataString(route);
            //2022/08/30, weird, it catches the 400 then response is populated.. 
            string tst = string.Empty;
            try
            {
                var authConstants = new AuthConstants(configuration);
                var localStorageKey = authConstants.LocalStorageKeyForJwt;
                var jwt = await localStorage.GetItemAsync<string>(localStorageKey);

                //got to be a better way than manually setting it... damn, this will go in new base, private method here
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

                var responseTEST = await httpClient.GetAsync(route); //This might be the way
                
                
                
                
                /* OR... don't worry about returning just the base, return the whole model and assume it is inherited correctly. You could still do something with the 400 though
                
                //var moreTst = responseTEST.Content.ReadAsStringAsync();
                if (responseTEST.StatusCode == HttpStatusCode.BadRequest)
                {
                    //TODO parse to business rule exception model , throw exception? 

                    //So this works but how can I get this to return with generics? 
                    return HandleBusinessRuleException<T>(responseTEST.Content); 
                    var baseModelToAllClientModels = HandleBusinessRuleException(responseTEST.Content);
                    //return baseModelToAllClientModels;
                    return default; //???
                }
                
                //var response = await httpClient.GetStringAsync(route);
                */

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
                var authConstants = new AuthConstants(configuration);
                var localStorageKey = authConstants.LocalStorageKeyForJwt;
                var jwt = await localStorage.GetItemAsync<string>(localStorageKey);

                //got to be a better way than manually setting it... damn, this will go in new base, private method here
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

                /* looks the same
                var authConstants = new AuthConstants(configuration);
                var localStorageKey = authConstants.LocalStorageKeyForJwt;
                var jwt = await localStorage.GetItemAsync<string>(localStorageKey);

                //got to be a better way than manually setting it... damn
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);
                */


                string serialized = Newtonsoft.Json.JsonConvert.SerializeObject(postObject);
                StringContent stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

                var httpResponseMessage = await httpClient.PostAsync(route, stringContent);
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    //TODO process error message
                    if (httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        //So how do I tell beween a regular exception and a business rule exception?
                        var tmp = await httpResponseMessage.Content.ReadAsStringAsync();

                    }
                    return default;
                }

                var tst = await httpResponseMessage.Content.ReadAsStringAsync();
                if (tst == null)
                    return default;

                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(tst);

                //..todo get the response model out of this... 
                //httpResponseMessage. 
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

            var authConstants = new AuthConstants(configuration);
            var localStorageKey = authConstants.LocalStorageKeyForJwt;
            var jwt = await localStorage.GetItemAsync<string>(localStorageKey);

            //got to be a better way than manually setting it... damn, this will go in new base, private method here
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);




            string serialized = Newtonsoft.Json.JsonConvert.SerializeObject(postObject);
            StringContent stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            var httpResponseMessage = await httpClient.PostAsync(route, stringContent);
            var tst = await httpResponseMessage.Content.ReadAsStringAsync();
            if (tst == null)
                return default;

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(tst);

            //..todo get the response model out of this... 
            //httpResponseMessage. 

        }


        private DeprecatedBaseExceptionModel HandleBusinessRuleException<T>(HttpContent content)
        {
            var payload = content.ReadAsStream();

            if (payload == null)
                return default;

            using (StreamReader reader = new StreamReader(payload))
            {
                var response = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<DeprecatedBaseExceptionModel>(response);
            }
        }

    }

   


}

using ContractTracker.Common.ClientAndServerModels.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ContractTracker.Common.SecurityModels;
using ContractTracker.Common.Functionality;
using ContractTracker.Services.Authentication.Factories;
using ContractTracker.Services.Authentication.Models;

namespace ContractTracker.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : BaseApiController
    {
        public AuthenticationController() { }

        [HttpPost("loginuser")]
        [AllowAnonymous]
        public async Task<string> LoginUser(UserAuthenticationRequestModel userAuthenticationRequestModel)
        {
            if (string.IsNullOrEmpty(userAuthenticationRequestModel.UserName)) //TODO, if any of the fields are empty, return empty token
                return await Task.FromResult(string.Empty);

            var authFactory = new AuthenticationFactory();
            var authenticationService = authFactory.BuildAuthenticatonService(true);

            var authRequest = new AuthenticationRequestModel()
            {
                Domain = userAuthenticationRequestModel.Domain,
                Password = userAuthenticationRequestModel.Password,
                UserName = userAuthenticationRequestModel.UserName
            };
            var authResponse = authenticationService.VerifyUser(authRequest);

            if (!authResponse.IsVerified)
                return await Task.FromResult(string.Empty);

            //Here we will use the user name and userAuthenticationRequestModel.Password to verify against the on premise AD if the user is someone we know.
            var commonAuthenticatedUserModel = new CommonAuthenticatedUserModel();
            commonAuthenticatedUserModel.UserName = userAuthenticationRequestModel.Domain + @"\" + userAuthenticationRequestModel.UserName; 

            //TODO, issuer and audience should be passed in here from configuration! 
            var tokenBuilder = new TokenBuilder();
            var jwt = tokenBuilder.BuildToken(commonAuthenticatedUserModel);

            return await Task.FromResult(jwt);



        }
    }
}

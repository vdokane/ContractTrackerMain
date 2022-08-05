using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using ContractTracker.Services.Business.Factories;
using ContractTracker.Common.ClientAndServerModels.Vendor;

namespace ContractTracker.API.Controllers
{
    [Route("api/vendor")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VendorApiController : BaseApiController
    {
        [HttpGet("getvendorbyid")]
        public async Task<VendorResponseModel> GetVendorById(int vid)
        {
            var response = await Task.FromResult(  new VendorResponseModel() { VendorId = vid, W9Name = "mock" });
            return response;
        }
    }
}

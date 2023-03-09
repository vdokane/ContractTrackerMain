using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using ContractTracker.Services.Business.Factories;
using ContractTracker.Common.ClientAndServerModels.Vendor;
using ContractTracker.API.RequestModels.Vendors;

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

        [HttpGet("searchvendors")]
        public async Task<VendorResponseModel> SearchVendors(VendorSearchRequesApiModel request)
        {
            var response = await Task.FromResult(new VendorResponseModel() { VendorId = 1000, W9Name = "mock" });
            return response;
        }
    }
}

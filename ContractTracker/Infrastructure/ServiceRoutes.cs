namespace ContractTracker.Infrastructure
{
    internal class ServiceRoutes
    {
        public static string LoginApiUrl { get { return "/api/authentication/loginuser"; } }


        internal class User
        {
            public static string GetUserByUsernameApiUrl(string username)
            {
                return $"/api/user/getuserbyusername?username={Uri.EscapeDataString(username)}";
            }
        }

        internal class Vendor
        {
            public static string GetVendorByIdApiUrl(int vendorId)
            {
                return $"/api/vendor/getvendorbyid?vid={vendorId}";
            }
        }

        internal class Sandbox
        {
            public static string GetComplexModelApiUrl()
            {
                return $"/api/sandbox/getcomplexmodel";
            }

            public static string GetComplexModelWithParamsApiUrl(int userId, string userName)
            {
                return $"/api/sandbox/getcomplexmodelwithparams?userid={userId}&username={Uri.EscapeDataString(userName)}";
            }

            public static string PostObjectApiUrl()
            {
                return $"/api/sandbox/insertuser";
            }
            public static string KaboomApiUrl()
            {
                return $"/api/sandbox/kaboom";
            }
            public static string KaboomBusinessRuleApiUrl()
            {
                return $"/api/sandbox/businessruleexception";
            }

            public static string DocumentUpload()
            {
                return $"/api/sandbox/documentupload";
            }
        }
    }
}

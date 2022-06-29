

namespace ContractTracker.Authentication
{
    public class AuthConstants
    {
        private readonly IConfiguration config;
        public AuthConstants(IConfiguration config)
        {
            this.config = config;
        }
        public string LocalStorageKeyForAuthUserModel { get { return config["LocalStorageKeyForAuthUserModel"]; } }
        public string LocalStorageKeyForJwt { get { return config["LocalStorageKeyForJwt"]; } }
    }
}

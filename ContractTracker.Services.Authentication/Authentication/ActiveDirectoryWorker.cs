using System.DirectoryServices;

namespace ContractTracker.Services.Authentication.Authentication
{
    public class ActiveDirectoryWorker
    {
        private string _domain;
        private string _userName;
        private readonly string _password;

        public ActiveDirectoryWorker(string strDomain, string strUserName, string strPassWord)
        {
            _domain = strDomain;
            _userName = strUserName;
            _password = strPassWord;
        }


        public ADUser GetUser()
        {
            var ldapServerPath = string.Empty;
            if (_domain != null)
                ldapServerPath = (_domain.ToLower() == "flcourts") ? "LDAP://xxxxxxx.int" : "LDAP://xxxxxxxxxxxx.pub";

            var bFound = false;
            var name = string.Empty;
            var userName = string.Empty;
            var emailAddress = string.Empty;
            var title = string.Empty;
            var phoneNumber = string.Empty;

            try
            {
                var searchRoot = new DirectoryEntry(ldapServerPath, _userName, _password);
                var search = new DirectorySearcher(searchRoot);
                search.PropertiesToLoad.Add("displayname");
                search.PropertiesToLoad.Add("sAMAccountName");
                search.PropertiesToLoad.Add("title");
                search.PropertiesToLoad.Add("phone");
                search.PropertiesToLoad.Add("mail");
                search.Filter = "(SAMAccountName=" + _userName + ")";
                var searchResult = search.FindOne(); //Here it does the magic!


                if (!string.IsNullOrEmpty(searchResult.Properties["displayname"][0].ToString())) bFound = true;


                if (bFound)
                {
                    name = searchResult.Properties["displayname"][0].ToString();
                    userName = searchResult.Properties["sAMAccountName"][0].ToString();

                    try
                    {
                        emailAddress = searchResult.Properties["mail"][0].ToString();
                    }
                    catch
                    { }

                    try
                    {
                        title = searchResult.Properties["title"][0].ToString();
                        phoneNumber = searchResult.Properties["phone"][0].ToString();

                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                string dbug = ex.ToString();
                bFound = false;
            }

            ADUser USER = new ADUser(ldapServerPath, _domain, bFound);
            USER.Name = name;
            USER.UserName = userName;
            USER.EMailAddress = emailAddress;
            USER.Title = title;
            USER.PhoneNumber = phoneNumber;

            return USER;
        }

    }
}


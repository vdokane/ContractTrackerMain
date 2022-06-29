using System;
using System.Text;
using System.DirectoryServices;

namespace ContractTracker.Services.Authentication.Authentication
{
    [Serializable]
    public class ADUser
    {
        public ADUser(string adpath, string addomain, bool found)
        {
            _path = adpath;
            _domain = addomain;
            _userfound = found;
        }


        string _filterAttribute;
        string _userid;
        string _path;
        string _domain;
        string _name;
        string _title;
        string _email;
        string _phone;
        bool _bademail = true;
        bool _userfound = false;
        public string ADPath { get { return _path; } }
        public string ADDomain { get { return _domain; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string EMailAddress { get { return _email; } set { _email = value; } }
        public string PhoneNumber { get { return _phone; } set { _phone = value; } }
        public string UserName { get { return _userid; } set { _userid = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public bool BadEmailAddress { get { return _bademail; } set { _bademail = value; } } //What was this used for?
        public bool UserFound { get { return _userfound; } }


        private bool IsAuthenticated(String strPath, String strDomain, String username, String pwd)
        {
            bool bRetVal = false;
            DirectoryEntry entry = new DirectoryEntry(strPath, strDomain + @"\" + username, pwd);

            try
            {
                Object obj = entry.NativeObject;                    //Bind to the native AdsObject to force authentication.			

                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();

                if (null != result)
                {
                    bRetVal = true;
                }

                _path = result.Path;                                //Update the new path to the user in the directory.
                _filterAttribute = (String)result.Properties["cn"][0];
            }
            catch
            {
            }

            return bRetVal;
        }

        private String GetGroups(String strPath, String strDomain, String username, String pwd)
        {
            DirectoryEntry entry = new DirectoryEntry(strPath, strDomain + @"\" + username, pwd);
            DirectorySearcher search = new DirectorySearcher(entry);
            //        DirectorySearcher search = new DirectorySearcher(_path);
            search.Filter = "(cn=" + _filterAttribute + ")";
            search.PropertiesToLoad.Add("memberOf");
            StringBuilder groupNames = new StringBuilder();

            try
            {
                SearchResult result = search.FindOne();

                int propertyCount = result.Properties["memberOf"].Count;

                String dn;
                int equalsIndex, commaIndex;

                for (int propertyCounter = 0; propertyCounter < propertyCount; propertyCounter++)
                {
                    dn = (String)result.Properties["memberOf"][propertyCounter];

                    equalsIndex = dn.IndexOf("=", 1);
                    commaIndex = dn.IndexOf(",", 1);
                    if (-1 == equalsIndex)
                    {
                        return null;
                    }

                    groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
                    groupNames.Append("|");

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error obtaining group names. " + ex.Message);
            }
            return groupNames.ToString();
        }

    }
}

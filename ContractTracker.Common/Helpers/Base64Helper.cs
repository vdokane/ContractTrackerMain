using System.Text;

namespace ContractTracker.Common.Helpers
{
    public class Base64Helper
    {
        public static string Encode(string value)
        {
            return System.Convert.ToBase64String(Encoding.ASCII.GetBytes(value));  //Encode for quick entropy
        }

        public static string Decode(string encodedValue)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(encodedValue);
            return Encoding.ASCII.GetString(encodedDataAsBytes);
        }
    }
}

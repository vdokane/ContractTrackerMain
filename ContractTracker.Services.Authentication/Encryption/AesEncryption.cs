using ContractTracker.Services.Authentication.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace ContractTracker.Services.Authentication.Encryption
{
    /*
    public class AesEncryption : IEncryptionService
    {
        private readonly AesCryptoServiceProvider aesCryptoServiceProvider;
        public AesEncryption()
        {
            //Unlike the example, keep the key and method contained in the encryption instance so the interface can be more generic and reused. 
            this.aesCryptoServiceProvider = new AesCryptoServiceProvider();
            //Both must be 16 characters to be 128 bits
            aesCryptoServiceProvider.Key = Encoding.ASCII.GetBytes("8Q898enlYXKCJBao");  //Do not have this in a config. However, if this goes to a public repo MAKE SURE YOU REMOVE THIS TO A SECRET
            aesCryptoServiceProvider.IV = Encoding.ASCII.GetBytes("HR$2pIjHR$2pIj12");  //Do not have this in a config. However, if this goes to a public repo MAKE SURE YOU REMOVE THIS TO A SECRET
        }
        public byte[] EncryptStringToBytes(string plainText)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (aesCryptoServiceProvider.Key == null || aesCryptoServiceProvider.Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (aesCryptoServiceProvider.IV == null || aesCryptoServiceProvider.IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;



            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = aesCryptoServiceProvider.CreateEncryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public string DecryptStringFromBytes(byte[] cipherText)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (aesCryptoServiceProvider.Key == null || aesCryptoServiceProvider.Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (aesCryptoServiceProvider.IV == null || aesCryptoServiceProvider.IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = aesCryptoServiceProvider.CreateDecryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }
    }
    */
}

namespace ContractTracker.Services.Authentication.Interfaces
{
    public interface IEncryptionService
    {
        byte[] EncryptStringToBytes(string plainText);
        string DecryptStringFromBytes(byte[] cipherText);
    }
}

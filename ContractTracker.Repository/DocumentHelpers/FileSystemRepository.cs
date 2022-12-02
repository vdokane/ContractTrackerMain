namespace ContractTracker.Repository.DocumentHelpers
{
    public class FileSystemRepository
    {
        public FileSystemRepository() { }

        public byte[]? GetFile(string path)
        {
            if (!File.Exists(path))
                return null;

            using (FileStream sr = File.Open(path,FileMode.Open))
            {
                MemoryStream ms = new MemoryStream();
                sr.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}

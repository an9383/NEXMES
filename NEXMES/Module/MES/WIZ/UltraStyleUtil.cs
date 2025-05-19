using System.IO;

namespace WIZ
{
    public class UltraStyleUtil
    {
        private string AppPath = string.Empty;

        private string IslFile = string.Empty;

        public UltraStyleUtil(string Path, string File)
        {
            AppPath = Path;
            IslFile = File;
        }

        public string GetIsl()
        {
            return Path.Combine(AppPath, IslFile);
        }
    }
}

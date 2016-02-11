using System.IO;

namespace com.jussipalo.tahti
{
    class Common
    {
        public static string CreateValidFilename(string filename)
        {
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            foreach (char c in invalid)
            {
                filename = filename.Replace(c.ToString(), "");
            }

            return filename;
        }
}
}

using System.Collections.Generic;
using System.IO;

namespace com.jussipalo.tahti
{
    class Common
    {
        public static List<string> BasicAreas = new List<string>() { "Perusluistelu ja askeleet", "Liu'ut", "Hypyt", "Piruetit", "Esittäminen" };
        public static List<string> ExtendedAreas = new List<string>() { "Perusluistelu", "Askeleet, liu'ut ja siirtymiset", "Hypyt: Vaikeus ja monipuolisuus", "Hypyt: Laatu",
            "Piruetit: Vaikeus ja monipuolisuus", "Piruetit: Laatu", "Esittäminen ja suoritusvarmuus", "Musiikkiin luistelu" };

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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteProjectRacerPage.Domain
{
    public class ImageFetcher
    {
        public string[] GetImagesPaths()
        {
            string path = "wwwroot/uploads";
            var files = Directory.GetFiles(path);
            var images = new List<string>();
            foreach (var file in files)
            {
                string s = file.Replace("\\", " / ").Replace("wwwroot", "").Replace(" ", "");
                images.Add(s);
            }

            return images.ToArray();
        }
    }
}

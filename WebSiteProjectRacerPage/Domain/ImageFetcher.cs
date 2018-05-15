using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteProjectRacerPage.Domain
{
    public class ImageFetcher
    {
        public string[] GetImagesPaths()
        {
            var images = new List<string>();
            try
            {
                string path = "wwwroot/uploads";
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    string s = file.Replace("\\", " / ").Replace("wwwroot", "").Replace(" ", "");
                    images.Add(s);
                }
            }
            catch (IOException)
            {
                Debug.WriteLine("Path to pictures does not exsist");
            }
            return images.ToArray();
        }
    }
}

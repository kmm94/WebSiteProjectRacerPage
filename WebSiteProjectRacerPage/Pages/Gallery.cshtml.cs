using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebSiteProjectRacerPage.Pages
{
    public class GalleryModel : PageModel
    {
        public void OnGet()
        {
        }

        public string[] GetImages()
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSiteProjectRacerPage.Domain;

namespace WebSiteProjectRacerPage.Pages
{
    public class GalleryModel : PageModel
    {
        public void OnGet()
        {
        }

        public string[] GetImages()
        {
            var imf = new ImageFetcher();
            return imf.GetImagesPaths();
        }
    }
}
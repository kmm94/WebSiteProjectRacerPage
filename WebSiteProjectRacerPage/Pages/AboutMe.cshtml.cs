using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebSiteProjectRacerPage.Pages
{
    public class AboutMeModel : PageModel
    {
        public void OnGet()
        {
            
        }

        public HtmlString GetAboutmeText()
        {
            var dataFile = "PersistentData/AboutMe.txt";
            string result = "The file does not exist.";
            if (System.IO.File.Exists(dataFile))
            {
                var userData = System.IO.File.ReadAllLines(dataFile);
                if (userData == null)
                {
                    // Empty file.
                    result = "The file is empty.";
                } else
                {
                    result = null;
                    foreach (string item in userData)
                    {
                        result += item;
                    }
                }
            }

            return new HtmlString(result);
        }
    }
}
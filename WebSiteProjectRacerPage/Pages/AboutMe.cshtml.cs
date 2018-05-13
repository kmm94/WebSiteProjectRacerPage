using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSiteProjectRacerPage.Domain;

namespace WebSiteProjectRacerPage.Pages
{
    public class AboutMeModel : PageModel
    {
        AboutMeManager aboutMeManager = new AboutMeManager();
        public void OnGet()
        {
            
        }

        public HtmlString GetAboutmeText()
        {
            return new HtmlString(aboutMeManager.GetTextForAboutMe());
        }
    }
}
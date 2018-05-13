using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSiteProjectRacerPage.Domain;

namespace WebSiteProjectRacerPage.Pages
{
    public class AdminModel : PageModel
    {
        [BindProperty]
        public string AboutMeText { get; set; }
        [BindProperty]
        public string[] Subbs { get; set; }
        private EmailManager emailManager = new EmailManager();
        private AboutMeManager aboutMeManager = new AboutMeManager();

        public async Task OnGetAsync()
        {

            Task<string[]> getsub = new Task<string[]>(()=> emailManager.GetSubricbbers());
            Task<string> getaboutMeText = new Task<string>(() => aboutMeManager.GetTextForAboutMe());

           
            getsub.Start();
            getaboutMeText.Start();

            Subbs = await getsub;
            AboutMeText = await getaboutMeText;
        }

        public void OnPost()
        {
            aboutMeManager.SaveAboutMeText(AboutMeText);
        }







    }
}
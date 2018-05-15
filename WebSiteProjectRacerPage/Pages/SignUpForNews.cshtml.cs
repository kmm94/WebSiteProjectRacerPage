using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Net.Mail;
using System.Threading.Tasks;
using WebSiteProjectRacerPage.Domain;

namespace WebSiteProjectRacerPage.Pages
{
    public class SignUpForNewsModel : PageModel
    {
        public void OnGet()
        {

        }

        public void OnPost(string emailAddress)
        {
            var email = Request.Form["email"];
            var name = Request.Form["name"];

            new EmailManager().SendEmailAsync(name, email);
        }
    }
}
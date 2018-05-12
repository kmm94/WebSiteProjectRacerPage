using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Net.Mail;
using System.Threading.Tasks;

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

            SendEmailAsync(name, email).Wait();
        }

        private async Task SendEmailAsync(string name, string email)
        {
            using (var smtp = new SmtpClient())
            {
                //setting up message:
                MailMessage message = new MailMessage();
                message.To.Add(email);
                message.Subject = "Welcome follower!";
                message.From = new MailAddress("karimkuku@hotmail.com");
                message.Body = "Hi There " + name + "\n You have succesfully subcribed to my news letter";

                //setting up server connection
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("karimkuku@hotmail.com", "313Moller");
                SmtpServer.EnableSsl = true;
                SmtpServer.SendMailAsync(message);

                //saving email in a file
                string saveingEmail = "\n "+ email;
                System.IO.File.AppendAllTextAsync("mails/emails.txt", saveingEmail);
                Debug.WriteLine("email have been saved");
            }
        }
    }
}
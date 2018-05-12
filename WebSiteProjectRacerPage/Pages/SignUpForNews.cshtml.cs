using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

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

            SendEmailAsync(name, email);
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
                SmtpServer.Send(message);
                Debug.WriteLine("email have been saved");
            }
        }
    }
}
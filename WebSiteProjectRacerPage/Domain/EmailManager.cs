using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebSiteProjectRacerPage.Domain
{
    public class EmailManager
    {
        public static async Task SendEmailAsync(string name, string email)
        {
            var smtp = new SmtpClient();
            
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
                string saveingEmail = ";\n" + email;
                System.IO.File.AppendAllTextAsync("mails/emails.txt", saveingEmail);
                Debug.WriteLine("email have been saved");
            
        }

        public string[] GetSubricbbers()
        {
            var dataFile = "PersistentData/emails.txt";
            string result = "The file does not exist.";
            if (System.IO.File.Exists(dataFile))
            {
                var userData = System.IO.File.ReadAllLines(dataFile);
                if (userData == null)
                {
                    // Empty file.
                    result = "The file is empty.";
                }
                else
                {
                    result = null;
                    foreach (string item in userData)
                    {
                        result += item;
                    }
                }
            }
            string[] vs = result.Split(";").ToArray();
            return vs;
        }
    }
}

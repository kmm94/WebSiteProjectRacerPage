﻿using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebSiteProjectRacerPage.Domain
{
    public class EmailManager
    {
        private string emailFilePath = "PersistentData/emails.txt";

        public async Task SendEmailAsync(string name, string email)
        {
            /**
            * Inspiration from:
            * https://stackoverflow.com/questions/2470645/sending-mail-using-smtpclient-in-net
            * https://stackoverflow.com/questions/9201239/send-e-mail-via-smtp-using-c-sharp
            * https://stackoverflow.com/questions/9851319/how-to-add-smtp-hotmail-account-to-send-mail
            */
            var smtp = new SmtpClient();

            //setting up message:
            MailMessage message = new MailMessage();
            message.To.Add(email);
            message.Subject = "Welcome follower!";
            message.From = new MailAddress("karimkuku@hotmail.com");
            message.Body = "Hi There " + name + "\n You have succesfully subcribed to my news letter";

            //setting up server connection:
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("karimkuku@hotmail.com", "313Moller");
            SmtpServer.EnableSsl = true;
            //VS generated supress warning
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            SmtpServer.SendMailAsync(message);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed


            //saving email in a file:
            var emailFilePath = "PersistentData/emails.txt";
            try
            {
                string saveingEmail = ";\n" + email;
                            //VS generated supress warning
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                File.AppendAllTextAsync(emailFilePath, saveingEmail);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Debug.WriteLine("email have been saved");
            }
            catch (IOException)
            {
                Debug.WriteLine("The path does not exists! File Path: " + emailFilePath);
            }

        }

        public string[] GetSubricbbers()
        {
            //check that the file exists:
            string result = "The file does not exist or is empty.";
            if (File.Exists(emailFilePath))
            {
                var userData = File.ReadAllLines(emailFilePath);
                if (userData != null)
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

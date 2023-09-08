﻿using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using HN.Management.Engine.ViewModels;
using HN.Management.Manager.Services.Interfaces;

namespace HN.Management.Manager.Services
{
	public class EmailService : IEmailService
	{
        public async Task<string> ContactMe(ContactRequest contactRequest)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("it@crezcofoundation.org"); 
            mailMessage.To.Add("info@crezcofoundation.org");
            mailMessage.CC.Add("anaeltrabajo@gmail.com");
            mailMessage.CC.Add("jearsoft@gmail.com");
            mailMessage.CC.Add("nerm.animator@gmail.com");
                mailMessage.Subject = $"New Contact Received - {contactRequest.FullName}";
            mailMessage.Body = $"Dear Crezco Onboarding Team,\r\nThere is a new Contact Received: \r\nFullName: {contactRequest.FullName}, \r\nEmailAddress: {contactRequest.Email}, \r\nMessage: {contactRequest.Message}";

             var smtpClient = await this.GetSmtpClient();
            smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error: " + ex.Message);
            }

            return await Task.FromResult("Email Sent Successfully.");
        }

        public async Task<string> SendNewsletterProgram(string email) {

            var smtpClient = await this.GetSmtpClient();

            var mailMessage = new MailMessage()
            {
                Subject = $"Newsletter Program Request Received - {email}",
                From = new MailAddress("it@crezcofoundation.org"),
                Body = $"Dear Crezco Onboarding Team,\r\nI want to receive Newsletter Program, this is my email: {email}"
            };

            mailMessage.To.Add("info@crezcofoundation.org");
            mailMessage.CC.Add("anaeltrabajo@gmail.com");
            mailMessage.CC.Add("jearsoft@gmail.com");
            mailMessage.CC.Add("nerm.animator@gmail.com");
            smtpClient.Send(mailMessage);

            return await Task.FromResult("Email Sent Sucessfully.");
        }

        private async Task<SmtpClient> GetSmtpClient() {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("it@crezcofoundation.org", "grhgucmyiwffqsmf");
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Timeout = 20000;

            return await Task.FromResult(smtpClient);
        }
	}
}


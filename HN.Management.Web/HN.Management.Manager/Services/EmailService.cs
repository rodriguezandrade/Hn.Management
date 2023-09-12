﻿using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using HN.Management.Engine.ViewModels;
using HN.Management.Manager.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace HN.Management.Manager.Services
{
	public class EmailService : IEmailService
	{
        private readonly EmailOptions emailOptionsVal;

        public EmailService(IOptions<EmailOptions> emailOptions)
        {
            emailOptionsVal = emailOptions.Value;
        }
        public async Task<string> ContactMe(ContactRequest contactRequest)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(emailOptionsVal.From); 
            mailMessage.To.Add(emailOptionsVal.To);
            mailMessage.CC.Add(emailOptionsVal.Cc);
            //mailMessage.CC.Add("jearsoft@gmail.com");
            //mailMessage.CC.Add("nerm.animator@gmail.com");
                mailMessage.Subject = $"New Contact Received - {contactRequest.FullName}";
            mailMessage.Body = $"Dear Crezco Information Team,\r\nThere has been a new inquiry on the website. See the contact information below: \r\nName: {contactRequest.FullName}, \r\nEmailAddress: {contactRequest.Email}, \r\nMessage: {contactRequest.Message}";

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

            mailMessage.To.Add(emailOptionsVal.To);
            mailMessage.CC.Add(emailOptionsVal.Cc);
            smtpClient.Send(mailMessage);

            return await Task.FromResult("Email Sent Sucessfully.");
        }

        private async Task<SmtpClient> GetSmtpClient() {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = emailOptionsVal.Server;
            smtpClient.Port = emailOptionsVal.Port;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(emailOptionsVal.To, "grhgucmyiwffqsmf");
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Timeout = 20000;

            return await Task.FromResult(smtpClient);
        }
	}
}

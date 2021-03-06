﻿using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System.Threading.Tasks;
using System;

namespace OnlineShoppingWeb.Services
{
    public class SendEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Yi", "yi_chiang@outlook.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465);
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("yichiang00@gmail.com", Environment.GetEnvironmentVariable("EmailPassword"));
                client.Send(emailMessage);
                client.Disconnect(true);
           
            }
        }
    }
}

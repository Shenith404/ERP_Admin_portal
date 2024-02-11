﻿using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Net.Security;

namespace ERP.Admin.Infastructure.Email.EmailSender
{
    public class VerificationEmailSender : IVerificationEmailSender
    {
        public async Task<bool> SendVerificationEmailAsync(string email, string verificationLink)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("ERP System Faculty of Engineering UoR", "comecprogramming@gmail.com"));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = "Email Verification";

            // Use TextPart.Text to set the body content
            message.Body = new TextPart(TextFormat.Plain)
            {
                Text = $"Click the following link to verify your email: {verificationLink}" +
                $"" +
                $"\n You Default Password is Abc@123" +
                $"\n Please Change the password After the Login"
            };

            using (var smtpClient = new SmtpClient())
            {
                try
                {
                    smtpClient.ServerCertificateValidationCallback = (sender, certificate, chain, errors) =>
                    {
                        // Customize the certificate validation logic here
                        if (errors == SslPolicyErrors.None)
                            return true;

                        // Check if the certificate matches the expected host name
                        string expectedHostName = "smtp.gmail.com";
                        return certificate.Subject.Contains(expectedHostName);
                    };

                    smtpClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    Console.WriteLine($"Connected to ");

                    smtpClient.Authenticate("comecprogramming@gmail.com", "rixphfjzsglsjudk");
                    Console.WriteLine("Authenticated");

                    await smtpClient.SendAsync(message);
                    Console.WriteLine("Message sent");

                    return true;
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    Console.WriteLine($"Error: {ex}");
                    return false;
                }
                finally
                {
                    await smtpClient.DisconnectAsync(true);
                    Console.WriteLine("Disconnected");
                }
            }
        }
    }
}
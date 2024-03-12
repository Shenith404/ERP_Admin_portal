using ERP.UI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using ERP.Admin.Infastructure.Email.EmailSender;


namespace ERP.UI.Components.Account
{
    // Remove the "else if (EmailSender is IdentityNoOpEmailSender)" block from RegisterConfirmation.razor after updating with a real implementation.
    internal sealed class IdentityNoOpEmailSender : IEmailSender<ApplicationUser>
    {
        private readonly IEmailSender emailSender = new NoOpEmailSender();

        // custom email sender
        private IVerificationEmailSender verificationEmailSender =new VerificationEmailSender();


        public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
        {

            await verificationEmailSender.SendVerificationEmailAsync(email, confirmationLink);
            // emailSender.SendEmailAsync(email, "Confirm your email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");
            
        }

        public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
        {
            // emailSender.SendEmailAsync(email, "Reset your password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");
            await verificationEmailSender.SendVerificationEmailAsync(email, resetLink);

        }

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
            emailSender.SendEmailAsync(email, "Reset your password", $"Please reset your password using the following code: {resetCode}");
    }
}

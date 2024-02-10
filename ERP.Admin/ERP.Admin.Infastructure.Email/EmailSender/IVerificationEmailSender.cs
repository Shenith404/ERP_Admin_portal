using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Admin.Infastructure.Email.EmailSender
{
    public interface IVerificationEmailSender
    {
        Task<bool> SendVerificationEmailAsync(string email, string verificationLink);
    }
}

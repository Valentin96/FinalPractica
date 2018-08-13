using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
namespace WindowsFormsApp3
{
    class MailSender
    {
        public void sendMailForPasswordChange(string toMail, string codResetare){
        var fromAddress = new MailAddress("marian.ciufu65@gmail.com", "From Name");
        var toAddress = new MailAddress(toMail, "To Name");
        const string fromPassword = "parola1010@";
        const string subject = "Resetare parola Chat";
        string  body = codResetare;

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };
            using (var message = new MailMessage(fromAddress, toAddress)
    {
        Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
}
    }
}

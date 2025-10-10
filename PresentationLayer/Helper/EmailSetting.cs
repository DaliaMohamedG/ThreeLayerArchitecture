using System.Net;
using System.Net.Mail;

namespace PresentationLayer.Helper
{
    public class EmailSetting
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("dm1956@fayoum.edu.eg", "abcdefg");
            client.Send("dm1956@fayoum.edu.eg", email.To, email.Subject, email.Body);
        }
    }
}

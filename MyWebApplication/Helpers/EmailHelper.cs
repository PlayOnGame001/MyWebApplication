using MimeKit;
using MailKit.Net.Smtp;

namespace MyWebApplication.Helpers
{
    public class EmailHelper
    {
        public bool SendEmailPasswordReset(string userEmail, string link)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Project", "ivanna.mo091@gmail.com"));
            message.To.Add(new MailboxAddress("Имя человека", userEmail));
            message.Subject = "Сброс пароля на сайте.";
            message.Body = new TextPart("html")
            {
                Text = link,
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("ivanna.mo091@gmail.com", "ymtf ryas tyoa dqdu");

                try
                {
                    client.Send(message);
                    return true;
                }
                catch (Exception)
                {
                    //Logging information
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
            return false;
        }
    }
}

using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace MailClient
{
    class Scheduler
    {
        public static String To = Client.To;
        public static String Subject = Client.Subject;
        public static String Attachment = Client.Attachment;
        public static String Message = Client.Message;
        
        
        public static void sendMail() {
            
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;

                client.Credentials = new NetworkCredential(Login.user, Login.password);
                MailMessage msg = new MailMessage();
                msg.To.Add(Scheduler.To);
                msg.From = new MailAddress(Login.user);
                msg.Subject = (Scheduler.Subject);
                msg.Body = (Scheduler.Message);
                Attachment data = new Attachment(Scheduler.Attachment);
                msg.Attachments.Add(data);
                Console.WriteLine(To);
                Console.WriteLine(Subject);
                Console.WriteLine(Attachment);
                Console.WriteLine(Message);

                client.Send(msg);
                Console.WriteLine("Message sent succesfully!!!");
                   }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

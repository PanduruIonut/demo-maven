using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using MailClient;

namespace MailClient
{
    public class sendCmd
    {
        private String To;
        private String Sub;
        private String Att;
        private String Msg;
        private String Usr;
        private String Pass;

        public sendCmd(string to, string subject, string attachment, string message, string user, string pwd)
        //public sendCmd(string[] args)
        {
            To = to;
            Sub = subject;
            Att = attachment;
            Msg = message;
            Usr = user;
            Pass = pwd;


            Console.WriteLine("sendCmd " + To);
        }

        //public static string to = Client.To;

        static void Main(string[] args)
        {
            string to = args[0];
            string subject = args[1];
            string attachment = args[2];
            string message = args[3];
            string user = args[4];
            string password = args[5];

            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;

                client.Credentials = new NetworkCredential(user, password);
                MailMessage msg = new MailMessage();
                msg.To.Add(to);
                msg.From = new MailAddress(user);
                msg.Subject = (subject);
                msg.Body = (message);
                Attachment data = new Attachment(attachment);
                msg.Attachments.Add(data);
                client.Send(msg);
                Console.WriteLine("Mesaju' a fost trimis uăi!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }



            //new Client().getFormData();
            //Console.WriteLine("to:  "+to);
            //Console.WriteLine("To   "+MailClient.Client.To);
            //Console.WriteLine("Subject  " + MailClient.Client.Subject);
            //Console.WriteLine("msg  " + MailClient.Client.Message);
            //Console.WriteLine("From  " + MailClient.Login.user);
            //Console.WriteLine("password " + MailClient.Login.password);
            //Console.ReadLine();
        }
    }
}


using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using Microsoft.Win32.TaskScheduler;

namespace MailClient
{
    public partial class Client : Form
    {
        public static String To;
        public static String Subject;
        public static String Attachment;
        public static String Message;
        public static String User;
        public static String Password;

        public Client()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;

                client.Credentials = new NetworkCredential(Login.user, Login.password);
                MailMessage msg = new MailMessage();
                msg.To.Add(textBoxTo.Text);
                msg.From = new MailAddress(Login.user);
                msg.Subject = (textBoxSubject.Text);
                msg.Body = (textBoxMessage.Text);
                Attachment data = new Attachment(textBoxAttachment.Text);
                msg.Attachments.Add(data);
                client.Send(msg);
                MessageBox.Show("Succesfully send message!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxAttachment.Text = dlg.FileName.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login newLoginForm = new Login();
            newLoginForm.Show();
            this.Close();
        }

        public  void button2_Click(object sender, EventArgs e)
        {
            To = textBoxTo.Text;
            Subject = textBoxSubject.Text;
            Attachment = textBoxAttachment.Text;
            Message = textBoxMessage.Text;
            User = Login.user;
            Password = Login.password;
            using (TaskService ts = new TaskService())
            {
                int minutes;
                int hours;
                Int32.TryParse(textBoxTime.Text, out hours);
                Int32.TryParse(textBoxTime2.Text, out minutes);
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Does something";
                td.Triggers.Add(new TimeTrigger() { StartBoundary = DateTime.Now + TimeSpan.FromHours(hours) + TimeSpan.FromMinutes(minutes) });
                td.Actions.Add(new ExecAction(@"C:\Users\wyn\Documents\Visual Studio 2015\Projects\MailClient\sendMailCMD\bin\Debug\sendMailCMD.exe",$"{To} \"{Subject}\" \"{Attachment}\" \"{Message}\" {User} \"{Password}\""));
                ts.RootFolder.RegisterTaskDefinition("@Test", td);
                // ts.RootFolder.DeleteTask("Test");
            }

            sendCmd k = new sendCmd(To, Subject, Attachment, Message, "plm", "plm");



        }

        public void getFormData()
        {
            To = textBoxTo.Text;
            Subject = textBoxSubject.Text;
            Attachment = textBoxAttachment.Text;
            Message = textBoxMessage.Text;
            Console.WriteLine("To:" + To);
            Console.WriteLine("Subject:" + Subject);
            Console.WriteLine("msg:" + Message);
        }

        private void textBoxTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid value!");
            }
        }
    }
}
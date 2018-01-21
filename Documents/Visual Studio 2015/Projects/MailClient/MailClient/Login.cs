using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
 
{
    public partial class Login : Form
    {

        private Client form1;
       public  static String user;
        public static String password;
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
      
        
        private void button1_Click(object sender, EventArgs e)
        {
            form1 = new Client();
            form1.Show();
            user = textBoxUser.Text;
            password = textBoxPass.Text;
            this.Close();
        }
    }
}

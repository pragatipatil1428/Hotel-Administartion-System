using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RESTAURANT_MANAGEMENT_SYS
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                home f = new home();
                f.Show();
                textBox1.Text = "";
                textBox2.Text = "";

            }
            else
            {
                MessageBox.Show("You Have Entered Wrong Username or Password.....");
                textBox1.Focus();
            }
        }
    }
}

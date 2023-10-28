using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RESTAURANT_MANAGEMENT_SYS
{
    public partial class add_staff : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root; password=root; database=restaurant");
        public add_staff()
        {
            InitializeComponent();
            clearAll();
        }

        void clearAll()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void add_staff_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "") 
            {
                if (textBox4.Text.Length > 10 || textBox4.Text.Length < 10)
                {
                    MessageBox.Show("Enter Corrrect phone number");
                }
                else
                {
                    try
                    {
                        con.Open();
                        String query = "insert into staff_details(name,position,address,mobile,joiningdate)Values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text+ "')";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show(textBox1.Text+" added to your staff as "+ comboBox1.Text);
                        clearAll();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
        
            else
            {
                MessageBox.Show("All feilds are mandatory");
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

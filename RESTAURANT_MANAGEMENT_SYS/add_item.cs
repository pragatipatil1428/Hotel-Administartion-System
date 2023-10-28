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
    public partial class add_item : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=root; database=restaurant");
        public add_item()
        {
            InitializeComponent();
            newData();
        }

        void clearAll()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }
        void newData()
        {
            clearAll();
            Random randId = new Random();
            int id = randId.Next(1, 9999);
            string pId = "BN" + id.ToString();
            textBox1.Text = pId;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                
                    try
                    {
                        con.Open();
                        String query = "insert into add_items(id,name,price,date)Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "')";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show(textBox2.Text + " added to your items list");
                        newData();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                
            }

            else
            {
                MessageBox.Show("All feilds are mandatory");
            }
        }

        private void add_item_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

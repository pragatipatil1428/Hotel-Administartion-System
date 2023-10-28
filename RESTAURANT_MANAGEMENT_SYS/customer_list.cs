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
    public partial class customer_list : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=root; database=restaurant");

        public customer_list()
        {
            InitializeComponent();
            show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void show()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from customer_details", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            guna2DataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = guna2DataGridView1.Rows.Add();
                guna2DataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                guna2DataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                guna2DataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                guna2DataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                guna2DataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();
            }
        }

    }
}

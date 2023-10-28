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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void staffReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            staff_report r = new staff_report();
            r.Show();
        }

        private void addItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_item i = new add_item();
            i.Show();
        }

        private void itemsAvaliableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items_ava a = new items_ava();
            a.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            add_staff s = new add_staff();
            s.Show();

        }

        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            place_order p = new place_order();
            p.Show();
        }

        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customer_list c = new customer_list();
            c.Show();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You Want to logout ? ", "Some Title", MessageBoxButtons.YesNo);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        
    }
}

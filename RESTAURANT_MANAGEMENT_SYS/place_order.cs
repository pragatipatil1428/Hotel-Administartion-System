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
using DGVPrinterHelper;

namespace RESTAURANT_MANAGEMENT_SYS
{
    public partial class place_order : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=root; database=restaurant");

        public place_order()
        {
            InitializeComponent();
            show();
            newData();
            
            
        }

        void newData()
        {
            
            Random randId = new Random();
            int id = randId.Next(1, 9999);
            string pId = "BILL" + id.ToString();
            textBox4.Text = pId;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        void show()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from add_items", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            guna2DataGridView2.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = guna2DataGridView2.Rows.Add();
                guna2DataGridView2.Rows[n].Cells[0].Value = dr[0].ToString();
                guna2DataGridView2.Rows[n].Cells[1].Value = dr[1].ToString();
                guna2DataGridView2.Rows[n].Cells[2].Value = dr[2].ToString();
            }
        }

        public String pid;
        public double price;
        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (guna2DataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    guna2DataGridView2.CurrentRow.Selected = true;
                    pid = guna2DataGridView2.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtPrice.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtItemName.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();

                }
            }
            catch
            {

            }
        }

        public double quan;
        private void QuantityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                double quan = Double.Parse(this.QuantityNumericUpDown.Value.ToString());
                double price = Double.Parse(this.txtPrice.Text);
                txtTotal.Text = (quan * price).ToString();
            }
            catch
            {

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (txtItemName.Text != "" || txtPrice.Text != "")
            {
                if (txtTotal.Text != "0" && txtTotal.Text != "")
                {
                    try
                    {
                            String query2 = "insert into ordereditems(id,name,quantity,price,total)Values('"+ pid +"','" + txtItemName.Text + "','" + txtPrice.Text + "','" + QuantityNumericUpDown.Value + "','" + txtTotal.Text + "')";
                            MySqlCommand cmd5 = new MySqlCommand(query2, con);
                            cmd5.ExecuteNonQuery();
                            con.Close();
                            show();
                            showorder();
                        
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                    txtItemName.Text = "";
                    txtPrice.Text = "";
                    txtTotal.Text = "";
                    QuantityNumericUpDown.Value = 0;
                    guna2DataGridView1.ClearSelection();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Minimum Quantity need to be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please Select an Product First...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public double pretotal, ptotal;

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count > 1)
            {
                if (guna2DataGridView1.SelectedRows.Count == 1)
                {
                    try
                    {
                        con.Open();
                        
                        String query2 = "delete from ordereditems where id='" + pid + "'";
                        MySqlCommand cmd1 = new MySqlCommand(query2, con);
                        cmd1.ExecuteNonQuery();
                        con.Close();

                        // ---price set by addition
                        // ---generate random id for each add to cart element and assign that to PK in database

                        show();
                        showorder();
                        guna2DataGridView1.ClearSelection();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Product to Remove...");
                }
            }
            else
            {
                MessageBox.Show("There is No Product to Remove...");
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    guna2DataGridView1.CurrentRow.Selected = true;
                    pid = guna2DataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    price = Double.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
     
                }
            }
            catch
            {

            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (textBox2.Text.Length > 10 || textBox2.Text.Length < 10)
                {
                    MessageBox.Show("You have entered wrong phone number");
                }
                else
                {
                    try
                    {
                        con.Open();
                        DateTime dtt = DateTime.Now;
                        String currentdate = dtt.ToString();
                        String query = "insert into customer_details(bill_id,name,phone,total,date_time)Values('" + textBox4.Text + "','" + textBox1.Text + "','"+textBox2.Text+"','"+pretotal+ "','" + currentdate + "')";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        
                        MessageBox.Show("Your Bill For "+textBox1.Text+" is ready to print...");

                        DGVPrinter printer = new DGVPrinter();
                        printer.Title = "Bill Of " + textBox1.Text;
                        printer.SubTitle = string.Format("Date:{0}",DateTime.Now);
                        //printer.SubTitle = string.Format("Name:{0}", textBox1.Text);
                        printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                        printer.PageNumbers = true;
                        printer.PageNumberInHeader = false;
                        printer.PorportionalColumns = true;
                        printer.HeaderCellAlignment = StringAlignment.Near;
                        printer.Footer = "Total Amount :" + lbltotalamount.Text;
                        printer.FooterSpacing = 15;
                        printer.PrintDataGridView(guna2DataGridView1);

                        MySqlCommand cmd2 = new MySqlCommand("delete from ordereditems", con);
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        pretotal = 0;
                        guna2DataGridView1.Rows.Clear();
                        newData();
                        lbltotalamount.Text = "Rs." + pretotal;


                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }

            }
            else
            {
                MessageBox.Show("Customers Details are not valid....");
            }
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from add_items where id like '%" + textBox3.Text.ToString() + "%' or name like '%" + textBox3.Text.ToString() + "%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            guna2DataGridView2.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = guna2DataGridView2.Rows.Add();
                guna2DataGridView2.Rows[n].Cells[0].Value = dr[0].ToString();
                guna2DataGridView2.Rows[n].Cells[1].Value = dr[1].ToString();
                guna2DataGridView2.Rows[n].Cells[2].Value = dr[2].ToString();
               
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void showorder()
        {
            con.Open();
            pretotal = 0.00;
            MySqlDataAdapter sda1 = new MySqlDataAdapter("select * from ordereditems", con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            guna2DataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                    int n = guna2DataGridView1.Rows.Add();
                    guna2DataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                    guna2DataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                    guna2DataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                    guna2DataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                    guna2DataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();

                    ptotal = double.Parse(dr[4].ToString());
                    pretotal = pretotal + ptotal;
                    lbltotalamount.Text = "Rs." + pretotal;
                
            }
            con.Close();
        }
    }
}

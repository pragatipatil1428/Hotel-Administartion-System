﻿using System;
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
    public partial class items_ava : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=root; database=restaurant");

        public items_ava()
        {
            InitializeComponent();
            show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public String id;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String query1 = "delete from add_items where id ='" + id + "'";
                MySqlCommand cmd = new MySqlCommand(query1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Item of -- " + id + " -- is Deleted Successfully....");
                show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        void show()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from add_items", con);
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
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                guna2DataGridView1.CurrentRow.Selected = true;
                id = guna2DataGridView1.Rows[e.RowIndex].Cells["Column1"].FormattedValue.ToString();
            }
        }
    }
    }

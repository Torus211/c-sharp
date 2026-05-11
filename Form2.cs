using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public NpgsqlConnection con;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public Form2(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }


        public void UpdateData()
        {
            String sql = " Select * from Product";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Номер";
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Единица измерения";
            //dataGridView1.Columns[3].HeaderText = "Номер";
            this.StartPosition = FormStartPosition.CenterScreen;




        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form3 form3 = new Form3(con, -1);
            form3.ShowDialog();
            UpdateData();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells["id"].Value;  
            NpgsqlCommand command = new NpgsqlCommand("DELETE from Product where ID = :id", con);
            command.Parameters.AddWithValue("id" ,id);
            command.ExecuteNonQuery();
            UpdateData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells["id"].Value;
            string name = (string)dataGridView1.CurrentRow.Cells ["name"].Value;
            string ed = (string)dataGridView1.CurrentRow.Cells["ed"].Value;
            Form3 form3 = new Form3(con, id, name, ed);
            form3.ShowDialog();
            UpdateData();

        }
    }
}

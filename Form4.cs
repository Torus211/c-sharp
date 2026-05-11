using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public NpgsqlConnection con;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public Form4(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }


        public void UpdateData()
        {
            String sql = " Select * from Client";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "id";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Адрес";
            dataGridView1.Columns[3].HeaderText = "Номер";
            this.StartPosition = FormStartPosition.CenterScreen;




        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
            NpgsqlCommand command = new NpgsqlCommand("DELETE from Client where ID = :id", con);
            command.Parameters.AddWithValue("id", id);
            command.ExecuteNonQuery();
            UpdateData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAddClient form5 = new FormAddClient(con);
            form5.ShowDialog();
            UpdateData();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
            string name = (string)dataGridView1.CurrentRow.Cells["Name"].Value;
            string adress = (string)dataGridView1.CurrentRow.Cells["adress"].Value;
            string phone = (string)dataGridView1.CurrentRow.Cells["phone"].Value;
            FormAddClient f = new FormAddClient(con,id,  name, adress, phone);
            f.ShowDialog();
            UpdateData();

        }
    }
}


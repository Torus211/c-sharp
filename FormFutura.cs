using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormFutura : Form
    {
        public NpgsqlConnection con;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        NpgsqlDataAdapter da = new NpgsqlDataAdapter();

        public FormFutura(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }


        public void UpdateData()
        {
            string sql = "SELECT futura.id, futura.data, client.name FROM futura JOIN client ON futura.id_client = client.id";
            da = new NpgsqlDataAdapter(sql, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;




        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
            NpgsqlCommand command = new NpgsqlCommand("DELETE from Futura where ID = :id", con);
            command.Parameters.AddWithValue("id", id);
            command.ExecuteNonQuery();
            UpdateData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormFuturaAdd form5 = new FormFuturaAdd(con);
            form5.ShowDialog();
            UpdateData();
        }

        private void FormFutura_Load(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}

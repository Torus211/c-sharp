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
    public partial class FormFuturaAdd : Form
    {
        public NpgsqlConnection con;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        public FormFuturaAdd(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void Update()
        {
            string aql = "select * from client";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
          
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO Futura (id_client, data, totalsum) VALUES (:id_client, :data,0)", con);

                DateTime dt = this.dateTimePicker1.Value.Date;
                command.Parameters.AddWithValue("id_client", comboBox1.SelectedValue);
                command.Parameters.AddWithValue("data", dt);
              
                command.ExecuteNonQuery();
                Close();
            }
            catch { }
        }
    }
}

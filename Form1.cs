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
    public partial class Form1 : Form
    {
        public NpgsqlConnection con;
        public Form1()
        {
            InitializeComponent();
            MyLoad();
        }
        
        public void MyLoad()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            con = new NpgsqlConnection("Server=localhost;Port=5432;UserID=postgres;Password=postpass;Database=torus");
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fp = new Form2(con);
            fp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(con);
            form4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormFutura formFutura = new FormFutura(con);
            formFutura.ShowDialog();
        }
    }
}

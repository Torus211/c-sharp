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
    public partial class Form3 : Form
    {
        public NpgsqlConnection con;
        int id;
        public Form3(NpgsqlConnection con, int id)
        {
            InitializeComponent();
            this.con = con;
            this.id  = id;
            
        }
        public Form3(NpgsqlConnection con, int id, string name, string ed)
        {
            InitializeComponent();
            textBox1.Text = name;
            textBox2.Text = ed;
            this.con = con;
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id == -1)
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO Product (name, ed) VALUES (:name, :ed)", con);
                    command.Parameters.AddWithValue("name", textBox1.Text);
                    command.Parameters.AddWithValue("ed", textBox2.Text);
                    command.ExecuteNonQuery();
                    Close();
                }
                catch { }
            }
            else
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("UPDATE Product SET  name = :name, ed = :ed WHERE ID = :id", con);
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("name", textBox1.Text);
                    command.Parameters.AddWithValue("ed", textBox2.Text);
                    command.ExecuteNonQuery();
                    Close();
                }
                catch { }
            }
        }
    }
}

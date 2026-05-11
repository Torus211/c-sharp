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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class FormAddClient : Form
    {
        
        
            public NpgsqlConnection con;
            int id; 
            public FormAddClient(NpgsqlConnection con)
            {
                InitializeComponent();
                this.con = con;
                this.id = id;
            }
            public FormAddClient(NpgsqlConnection con, int id, string name, string adress, string phone)
        {
            InitializeComponent();
            textBox1.Text = name;
            textBox2.Text = adress;
            textBox3.Text = phone;
            this.con = con;
            this.id = id;
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (id == -1)
            {

                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO Client (name, adress, phone) VALUES (:name, :adress, :phone)", con);
                    command.Parameters.AddWithValue("name", textBox1.Text);
                    command.Parameters.AddWithValue("adress", textBox2.Text);
                    command.Parameters.AddWithValue("phone", textBox3.Text);
                    command.ExecuteNonQuery();
                    Close();
                }
                catch { }
            }
            else
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("UPDATE Client SET  name=:name, adress =:adress, phone=:phone WHERE id = :id", con);
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("name", textBox1.Text);
                    command.Parameters.AddWithValue("adress", textBox2.Text);
                    command.Parameters.AddWithValue("phone", textBox3.Text);
                    command.ExecuteNonQuery();
                    Close();
                }
                catch { }
            }
        }
    }
    }



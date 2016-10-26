using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;

namespace dbase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string a; string b;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connectionString = "Server=192.168.54.21;Port=5432;User=shtyrba;Password=gBTnz9;Database=goshchina;";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open(); 
            a = textBox1.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(a, npgSqlConnection);
            NpgsqlCommandBuilder cd = new NpgsqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "grousdssds");
           
           
            dataGridView1.DataSource = ds.Tables[0];
            npgSqlConnection.Close(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string asd = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string str = dataGridView1.Columns[e.ColumnIndex].Name.ToString();
            String connectionString = "Server=192.168.54.21;Port=5432;User=shtyrba;Password=gBTnz9;Database=goshchina;";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
           // b = "select * from students";
            b = "select * from studentsgroup where group_id ="+asd;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(b, npgSqlConnection);
            NpgsqlCommandBuilder cd = new NpgsqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "grousdssds");
            dataGridView1.DataSource = ds.Tables[0];
            MessageBox.Show(asd,str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        
    }
}

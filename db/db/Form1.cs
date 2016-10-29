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

namespace db
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

       

        private void button1_Click_1(object sender, EventArgs e)
        {

            String CS = "Server=spsu.ru;Port=5433;User=shtyrba;Password=gBTnz9;Database=goshchina;";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(CS);
            npgSqlConnection.Open();
            a = textBox1.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(a, npgSqlConnection);
            NpgsqlCommandBuilder cd = new NpgsqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "grousdssds");


            dataGridView1.DataSource = ds.Tables[0];
            npgSqlConnection.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string asd = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string str = dataGridView1.Columns[e.ColumnIndex].Name.ToString();
            if (str=="group_name"||str=="abbr_name")
            {
                asd="\'"+asd+"\'";
            }
            String connectionString = "Server=spsu.ru;Port=5433;User=shtyrba;Password=gBTnz9;Database=goshchina;";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            b = String.Format ("select students.id,students.students_name,period,group_id,abbr_name from students,studentsgroup,groups where students.id=studentsgroup.students_id and groups.id=studentsgroup.group_id and groups.{1} ={0}",asd,str);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(b, npgSqlConnection);
            NpgsqlCommandBuilder cd = new NpgsqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
           // textBox1.Text = b;
            listBox1.DataSource = ds.Tables[0].Columns[0];
            npgSqlConnection.Close();
        }

       

    }
}
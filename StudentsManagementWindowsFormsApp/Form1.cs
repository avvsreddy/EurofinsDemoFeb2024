using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentsManagementWindowsFormsApp
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=StudentDB2024;Integrated Security=true");

        SqlDataAdapter da = null;
        DataSet ds = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // load data


            string selectSql = "select * from students";

            da = new SqlDataAdapter(selectSql, sqlConnection);
            ds = new DataSet();
            //sqlConnection.Open();

            da.Fill(ds, "students");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "students";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // update
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
            da.Update(ds, "students");
            MessageBox.Show("Students data updated");
        }
    }
}

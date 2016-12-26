using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WyborLaptopaOkienkowy
{
    public partial class Form3 : Form
    {
        SqlConnection connection;
        string connectionString; //contains info about database connection, name of database etc

        public Form3()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["WyborLaptopaOkienkowy.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            ShowNotebooks();
        }

        private void ShowNotebooks()
        {
            using (connection = new SqlConnection(connectionString))
            using(SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Notebooks",connection))
            {
                DataTable notebooksTable = new DataTable();
                adapter.Fill(notebooksTable);

                listBox1.DisplayMember = "Name";
                listBox1.ValueMember = "Laptop";
                listBox1.DataSource = notebooksTable;
            }
        }
    }
}

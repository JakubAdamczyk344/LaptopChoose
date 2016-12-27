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
        
        private static string size = Form2.getSize();
        private static string weight = Form2.getWeight();
        private static string processorPerformance = Form2.getProcessorPerformance();
        private static string graphicPerformance = Form2.getGraphicPerformance();
        private static string SSD = Form2.getSSD();
        private static string RAM = Form2.getRAM();
        private static string diskSpace = Form2.getDiskSpace();
        string sizeQuery;
        string weightQuery;
        string SSDQuery;
        string RAMQuery;
        string diskSpaceQuery;

        SqlConnection connection;
        string connectionString; //contains info about database connection, name of database etc
        string query = "SELECT * FROM Notebooks WHERE Size > 0 AND SSD = 'False'";
        private void createQuery() //here my query is created based on notebook's parameters
        {
            if (size == "all") sizeQuery = " Size > 0";
            if (size == "below and equal 15,6") sizeQuery = " Size <= 15.6";
            if (weight == "all") weightQuery = "Weight > 0";
            if (weight == "below and equal 2,5 kg") weightQuery = "Weight <= 2.5";
            if (SSD == "no") SSDQuery = " SSD = 'False'";
            if (SSD == "yes") SSDQuery = " SSD = 'True'";
            if (RAM == "below and equal 8 GB") RAMQuery = " RAM <= 8";
            if (RAM == "above 8 GB") RAMQuery = " RAM > 8";
            if (diskSpace == "below and equal 500 GB") diskSpaceQuery = " HDD + SSDCapacity <= 500";
            if (diskSpace == "above 500 GB") diskSpaceQuery = " HDD + SSDCapacity > 500";
            query = "SELECT * FROM Notebooks WHERE" + sizeQuery + " AND " + weightQuery + " AND " + "ProcessorPerformance = '" +
                processorPerformance + "' AND " + "GraphicPerformance = '" + graphicPerformance + "' AND " + SSDQuery +
                " AND " + RAMQuery + " AND " + diskSpaceQuery;
        }

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
            createQuery();
            textBox1.Text = query;
            using (connection = new SqlConnection(connectionString))
            using(SqlDataAdapter adapter = new SqlDataAdapter(query,connection))
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

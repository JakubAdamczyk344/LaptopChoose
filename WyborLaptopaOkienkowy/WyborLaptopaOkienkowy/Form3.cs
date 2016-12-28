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
        private string size = Form2.getSize();
        private string weight = Form2.getWeight();
        private string processorPerformance = Form2.getProcessorPerformance();
        private string graphicPerformance = Form2.getGraphicPerformance();
        private string SSD = Form2.getSSD();
        private string RAM = Form2.getRAM();
        private string diskSpace = Form2.getDiskSpace();
        string sizeQuery;
        string weightQuery;
        string SSDQuery;
        string RAMQuery;
        string diskSpaceQuery;

        SqlConnection connection;
        string connectionString; //contains info about database connection, name of database etc
        string query;
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
            query = "SELECT Name, Processor, Graphics, RAM, HDD, SSDCapacity FROM Notebooks WHERE" + sizeQuery + " AND " + weightQuery + " AND " + "ProcessorPerformance = '" +
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
            textBox2.Text = "Parametry dobranego laptopa: " + Environment.NewLine + "Rozmiar: " + size
                + Environment.NewLine + "Waga: " + weight + Environment.NewLine + "Wydajność procesora: " + processorPerformance
                + Environment.NewLine + "Wydajność karty graficznej: " + graphicPerformance + Environment.NewLine + "SSD: " + SSD
                + Environment.NewLine + "RAM: " + RAM + Environment.NewLine + "Disk space: " + diskSpace;
            createQuery();
            textBox1.Text = query;
            
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["Name"].ToString());
                listitem.SubItems.Add(dr["Processor"].ToString());
                listitem.SubItems.Add(dr["Graphics"].ToString());
                listitem.SubItems.Add(dr["RAM"].ToString());
                listitem.SubItems.Add(dr["HDD"].ToString());
                listitem.SubItems.Add(dr["SSDCapacity"].ToString());
                listView1.Items.Add(listitem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.Show();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

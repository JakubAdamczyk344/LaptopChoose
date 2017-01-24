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
        //Parametry laptopa w języku polskim, do wyświetlenia w podsumowaniu
        private string sizePol;
        private string weightPol;
        private string processorPerformancePol;
        private string graphicPerformancePol;
        private string SSDPol;
        private string RAMPol;
        private string diskSpacePol;
        //Fragmenty zapytania SQL do wyszukiwania laptopów w bazie danych
        string sizeQuery;
        string weightQuery;
        string SSDQuery;
        string RAMQuery;
        string diskSpaceQuery;
        string connectionString; //informacje o połączeniu z bazą danych
        string query; //zapytanie SQL
        //Metoda tworząca zapytanie SQL
        private void createQuery()
        {
            if (size == "all") sizeQuery = " Size > 0";
            if (size == "below and equal 15,6") sizeQuery = " Size <= 15.6";
            if (weight == "all") weightQuery = "Weight > 0";
            if (weight == "below and equal 3 kg") weightQuery = "Weight <= 3";
            if (SSD == "no") SSDQuery = " SSD = 'False'";
            if (SSD == "yes") SSDQuery = " SSD = 'True'";
            if (RAM == "below and equal 8 GB") RAMQuery = " RAM <= 8";
            if (RAM == "above 8 GB") RAMQuery = " RAM > 8";
            if (diskSpace == "below and equal 1000 GB") diskSpaceQuery = " HDD + SSDCapacity <= 1000";
            if (diskSpace == "above 1000 GB") diskSpaceQuery = " HDD + SSDCapacity > 1000";
            query = "SELECT Name, Size, Weight, Processor, Graphics, RAM, HDD, SSDCapacity, Price FROM Notebooks WHERE" 
                + sizeQuery + " AND " + weightQuery + " AND " + "ProcessorPerformance = '" +
                processorPerformance + "' AND " + "GraphicPerformance = '" + graphicPerformance + "' AND " + SSDQuery +
                " AND " + RAMQuery + " AND " + diskSpaceQuery;
        }
        //Konstruktor okna z podsumowaniem
        public Form3()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["WyborLaptopaOkienkowy.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            ShowNotebooks();
        }
        //Metoda wyświetlająca znalezione laptopy
        private void ShowNotebooks()
        {
            translate();
            textBox2.Text = "Parametry dobranego laptopa: " + Environment.NewLine + "Rozmiar: " + sizePol
                + Environment.NewLine + "Waga: " + weightPol + Environment.NewLine + "Wydajność procesora: " + processorPerformancePol
                + Environment.NewLine + "Wydajność karty graficznej: " + graphicPerformancePol + Environment.NewLine + "SSD: " + SSDPol
                + Environment.NewLine + "RAM: " + RAMPol + Environment.NewLine + "Pojemność dysku: " + diskSpacePol;
            createQuery();
            //Łączenie z bazą danych
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            //Wyświetlanie laptopów w liście
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["Name"].ToString());
                listitem.SubItems.Add(dr["Processor"].ToString());
                listitem.SubItems.Add(dr["Graphics"].ToString());
                listitem.SubItems.Add(dr["RAM"].ToString());
                listitem.SubItems.Add(dr["HDD"].ToString());
                listitem.SubItems.Add(dr["SSDCapacity"].ToString());
                listitem.SubItems.Add(dr["Size"].ToString());
                listitem.SubItems.Add(dr["Weight"].ToString());
                listitem.SubItems.Add(dr["Price"].ToString());
                listView1.Items.Add(listitem);
            }
        }
        //Metoda tłumacząca parametry laptów na język polski
        private void translate()
        {
            if (size == "all") sizePol = "wszystkie rozmiary";
            else sizePol = "do 15,6 cala";
            if (weight == "all") weightPol = "wszystkie wagi";
            else weightPol = "do 3 kg";
            if (processorPerformance == "low") processorPerformancePol = "niska";
            else if (processorPerformance == "medium") processorPerformancePol = "średnia";
            else processorPerformancePol = "wysoka";
            if (graphicPerformance == "low") graphicPerformancePol = "niska";
            else if (graphicPerformance == "medium") graphicPerformancePol = "średnia";
            else graphicPerformancePol = "wysoka";
            if (SSD == "yes") SSDPol = "tak";
            else SSDPol = "nie";
            if (RAM == "below and equal 8 GB") RAMPol = "do 8 GB";
            else RAMPol = "powyżej 8 GB";
            if (diskSpace == "below and equal 1000 GB") diskSpacePol = "do 1 TB";
            else diskSpacePol = "powyżej 1 TB";
        }
        //Metoda obsługująca kliknięcie na przycisk uruchamiający nowy dobór laptopa
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.Show();
        }
        //Metoda zamykająca aplikację po wyłączeniu okna
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

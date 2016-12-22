using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WyborLaptopaOkienkowy
{
    
    public partial class Form2 : Form
    {
        private readonly string[] questions = new string[9]; //initialize array which will contain questions
        List<Panel> panels = new List<Panel>();
        int whichQuestion = 0; //set number of first question to display
        static string size;
        static string weight;
        static string processorPerformance;
        static string graphicPerformance;
        static string SSD;
        static string RAM;
        static string HDD;
        static string ifTaken;
        static string travelBy;
        static string ifUse;
        static string ifGraphic;
        static string ifDesigner;
        static string ifGraphicJob;
        static string ifDesignerJob;
        static string ifPlayer;
        static string whichPlayer;

        public Form2()
        {
            InitializeComponent();
            questions[0] = "Czy zabierasz swojego laptopa w podróże?"; //full questions array with questions
            questions[1] = "Czy podróżujesz autem, czy komunikacją publiczną?";
            questions[2] = "Czy korzystasz z laptopa w podróży?";
            questions[3] = "Czy zajmujesz się obróbką grafiki (hobbystycznie lub zawodowo)?";
            questions[4] = "Czy to Twój zawód?";
            questions[5] = "Czy zajmujesz się projektowaniem grafiki 2D/3D lub projektowaiem CAD/CAM?";
            questions[6] = "Czy to Twój zawód?";
            questions[7] = "Czy grasz w gry komputerowe?";
            questions[8] = "Określ swój stosunek do gier komputerowych:";
            textBox1.Text = questions[whichQuestion];
            panels.Add(pnlAnswersQuestion0);
            panels.Add(pnlAnswersQuestion1);
            panels.Add(pnlAnswersQuestion2);
            panels.Add(pnlAnswersQuestion3);
            panels.Add(pnlAnswersQuestion4);
            panels.Add(pnlAnswersQuestion5);
            panels.Add(pnlAnswersQuestion6);
            panels.Add(pnlAnswersQuestion7);
            panels.Add(pnlAnswersQuestion8);
            setAnswers();
        }

        private void setQuestion() //function for displaying question due to number of question
        {
            textBox1.Text = questions[whichQuestion];
        }

        private void setAnswers() //function for displaying new answers
        {
            foreach (var panel in panels) //hide all panels
            {
                panel.Visible = false;
            }
            panels[whichQuestion].Visible = true; //show panel which contains answers for specific question
        }

        private void button1_Click(object sender, EventArgs e) //display next question and answers
        {
            skipQuestion();
            if (whichQuestion < 8)
            {
                whichQuestion++;
                setQuestion();
                setAnswers();
            }
            //if (whichQuestion == 9) whichQuestion = 0; //loop question and answer setting, only for tests
            else checkAnswers();
        }

        private void skipQuestion() //some questions need to be skipped if answer for previous question was "no"
        {
            
            if (whichQuestion == 0 && boxIfTakenNo.Checked == true)
            {
                whichQuestion = 2;
            }
            if (whichQuestion == 3 && boxIfGraphicNo.Checked == true)
            {
                whichQuestion = 4;
            }
            if (whichQuestion == 5 && boxIfDesignerNo.Checked == true)
            {
                whichQuestion = 6;
            }
            if (whichQuestion == 7 && boxIfPlayerNo.Checked == true)
            {
                whichQuestion = 8;
            }
        }
        private void checkAnswers() //here rules are checked and paramaters of notebook are adjusted
        {
            textBox1.Text = "Zakończono ankietę, czekaj na wynik wnioskowania";
            if (boxIfTakenNo.Checked == true)
            {
                size = "all";
                weight = "all";
            }
            if (boxIfTakenYes.Checked == true && boxTravelByPublic.Checked == true)
            {
                weight = "below and equal 2,5 kg";
            }
            if (boxIfTakenYes.Checked == true && boxTravelByAuto.Checked == true)
            {
                weight = "all";
            }
            if (boxIfTakenYes.Checked == true && boxIfUseYes.Checked == true)
            {
                size = "below and equal 15,6 cala";
            }
            if (boxIfTakenYes.Checked == true && boxIfUseNo.Checked == true)
            {
                size = "all";
            }
            if (boxIfDesignerNo.Checked == true && boxIfGraphicNo.Checked == true && boxIfPlayerNo.Checked == true)
            {
                processorPerformance = "low";
                graphicPerformance = "low";
                SSD = "no";
                HDD = "below and equal 500 GB";
                RAM = "below and equal 8 GB";
            }
            if ((boxIfDesignerYes.Checked == true && boxIfDesignerJobNo.Checked == true) || (boxIfPlayerYes.Checked == true && boxWhichPlayerRare.Checked == true))
            {
                processorPerformance = "medium";
                graphicPerformance = "medium";
                SSD = "no";
                HDD = "below and equal 500 GB";
                RAM = "below and equal 8 GB";
            }
            if (boxIfGraphicYes.Checked == true && boxIfGraphicJobYes.Checked == true)
            {
                processorPerformance = "medium";
                graphicPerformance = "medium";
                SSD = "no";
                HDD = "below and equal 500 GB";
                RAM = "below and equal 8 GB";
            }
            if (boxIfPlayerYes.Checked == true && boxWhichPlayerCasual.Checked == true)
            {
                processorPerformance = "medium";
                graphicPerformance = "high";
                SSD = "no";
                HDD = "below and equal 500 GB";
                RAM = "above 8 GB";
            }
            if (boxIfGraphicYes.Checked == true && boxIfGraphicJobYes.Checked == true)
            {
                processorPerformance = "high";
                if (graphicPerformance != "high") graphicPerformance = "medium";
                SSD = "yes";
                HDD = "below and equal 500 GB";
                RAM = "above 8 GB";
            }
            if ((boxIfDesignerYes.Checked == true && boxIfDesignerJobYes.Checked == true) || (boxIfPlayerYes.Checked == true && boxWhichPlayerManiac.Checked == true))
            {
                processorPerformance = "high";
                graphicPerformance = "high";
                SSD = "yes";
                HDD = "above 500 GB";
                RAM = "above 8 GB";
            }
            textBox1.Text = "Parametry dobranego laptopa: " + Environment.NewLine + "Rozmiar: " + size
                + Environment.NewLine + "Waga: " + weight + Environment.NewLine + "Wydajność procesora: " + processorPerformance
                + Environment.NewLine + "Wydajność karty graficznej: " + graphicPerformance + Environment.NewLine + "SSD: " + SSD
                + Environment.NewLine + "RAM: " + RAM + Environment.NewLine + "HDD: " + HDD;
        }
    }
}

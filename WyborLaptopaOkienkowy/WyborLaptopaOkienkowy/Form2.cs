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
        //List<CheckBox> checkBoxes = new List<CheckBox>();
        int whichQuestion = 0; //set number of first question to display
        public static string size; //dodać potem gettery i ustanowić te pola prywatnymi
        public static string weight;
        public static string processorPerformance;
        public static string graphicPerformance;
        public static string SSD;
        public static string RAM;
        public static string diskSpace;
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
            /*checkBoxes.Add(boxIfDesignerJobNo);
            checkBoxes.Add(boxIfDesignerJobYes);*/
            setAnswers();
        }

        private void setQuestion() //function for displaying question due to number of question
        {
            textBox1.Text = questions[whichQuestion];
        }

        private void setAnswers() //function for displaying possible answers for each question
        {
            foreach (var panel in panels) //hide all panels
            {
                panel.Visible = false;
            }
            panels[whichQuestion].Visible = true; //show panel which contains answers for specific question
        }

        private void button1_Click(object sender, EventArgs e) //display next question and answers
        {
            checkIfUserAnswered();
            skipQuestion();
            if (whichQuestion < 8)
            {

                whichQuestion++;
                setQuestion();
                setAnswers();
            }
            else
            {
                button1.Text = "Zakończ ankietę";
                checkAnswers();
                showSummary();
            }
            //if (whichQuestion == 9) whichQuestion = 0; //loop question and answer setting, only for tests
            
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
                processorPerformance = "low";//ok
                graphicPerformance = "low";
                SSD = "no";
                diskSpace = "below and equal 500 GB";
                RAM = "below and equal 8 GB";
            }
            if ((boxIfDesignerYes.Checked == true && boxIfDesignerJobNo.Checked == true) || (boxIfPlayerYes.Checked == true && boxWhichPlayerRare.Checked == true))
            {
                processorPerformance = "medium";//ok
                graphicPerformance = "medium";
                SSD = "no";
                diskSpace = "below and equal 500 GB";
                RAM = "below and equal 8 GB";
            }
            if (boxIfGraphicYes.Checked == true && boxIfGraphicJobYes.Checked == true)
            {
                processorPerformance = "medium";//ok
                graphicPerformance = "high";
                SSD = "yes";
                diskSpace = "below and equal 500 GB";
                RAM = "below and equal 8 GB";
            }
            if (boxIfPlayerYes.Checked == true && boxWhichPlayerCasual.Checked == true)
            {
                processorPerformance = "medium";//ok
                graphicPerformance = "high";
                SSD = "yes";
                diskSpace = "below and equal 500 GB";
                RAM = "above 8 GB";
            }
            if (boxIfGraphicYes.Checked == true && boxIfGraphicJobYes.Checked == true)
            {
                processorPerformance = "high";//ok
                if (graphicPerformance != "high") graphicPerformance = "medium";
                SSD = "yes";
                diskSpace = "below and equal 500 GB";
                RAM = "above 8 GB";
            }
            if ((boxIfDesignerYes.Checked == true && boxIfDesignerJobYes.Checked == true) || (boxIfPlayerYes.Checked == true && boxWhichPlayerManiac.Checked == true))
            {
                processorPerformance = "high";//ok
                graphicPerformance = "high";
                SSD = "yes";
                diskSpace = "above 500 GB";
                RAM = "above 8 GB";
            }
            textBox1.Text = "Parametry dobranego laptopa: " + Environment.NewLine + "Rozmiar: " + size
                + Environment.NewLine + "Waga: " + weight + Environment.NewLine + "Wydajność procesora: " + processorPerformance
                + Environment.NewLine + "Wydajność karty graficznej: " + graphicPerformance + Environment.NewLine + "SSD: " + SSD
                + Environment.NewLine + "RAM: " + RAM + Environment.NewLine + "HDD: " + diskSpace;
        }
        //Make sure that only one answer for every question can be checked
        private void boxIfTakenYes_CheckedChanged(object sender, EventArgs e)
        {
            if (boxIfTakenYes.Checked == true) boxIfTakenNo.Checked=false;
        }

        private void boxIfTakenNo_CheckedChanged(object sender, EventArgs e)
        {
            if (boxIfTakenNo.Checked == true) boxIfTakenYes.Checked = false;
        }

        private void boxTravelByAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (boxTravelByAuto.Checked == true) boxTravelByPublic.Checked = false;
        }

        private void boxTravelByPublic_CheckedChanged(object sender, EventArgs e)
        {
            if (boxTravelByPublic.Checked == true) boxTravelByAuto.Checked = false;
        }

        private void boxIfUseYes_CheckedChanged(object sender, EventArgs e)
        {
            if (boxIfUseYes.Checked == true) boxIfUseNo.Checked = false;
        }

        private void boxIfUseNo_CheckedChanged(object sender, EventArgs e)
        {
            if (boxIfUseNo.Checked == true) boxIfUseYes.Checked = false;
        }

        private void boxIfGraphicYes_CheckedChanged(object sender, EventArgs e)
        {
            if (boxIfGraphicYes.Checked == true) boxIfGraphicNo.Checked = false;
        }

        private void boxIfGraphicNo_CheckedChanged(object sender, EventArgs e)
        {
            if(boxIfGraphicNo.Checked == true) boxIfGraphicYes.Checked = false;
        }

        private void boxIfGraphicJobYes_CheckedChanged(object sender, EventArgs e)
        {
            if (boxIfGraphicJobYes.Checked == true) boxIfGraphicJobNo.Checked = false;
        }

        private void boxIfGraphicJobNo_CheckedChanged(object sender, EventArgs e)
        {
            if (boxIfGraphicJobNo.Checked == true) boxIfGraphicJobYes.Checked = false;
        }

        private void boxIfDesignerYes_CheckedChanged(object sender, EventArgs e)
        {
            if (boxIfDesignerYes.Checked == true) boxIfDesignerNo.Checked = false;
        }

        private void boxIfDesignerNo_CheckedChanged(object sender, EventArgs e)
        {
            if (boxIfDesignerNo.Checked == true) boxIfDesignerYes.Checked = false;
        }

        private void boxIfDesignerJobYes_CheckedChanged(object sender, EventArgs e)
        {
            if (boxIfDesignerJobYes.Checked == true) boxIfDesignerJobNo.Checked = false;
        }

        private void boxIfDesignerJobNo_CheckedChanged(object sender, EventArgs e)
        {
            if (boxIfDesignerJobNo.Checked == true) boxIfDesignerJobYes.Checked = false;
        }

        private void boxIfPlayerYes_CheckedChanged(object sender, EventArgs e)
        {
            if (boxIfPlayerYes.Checked == true) boxIfPlayerNo.Checked = false;
        }

        private void boxIfPlayerNo_CheckedChanged(object sender, EventArgs e)
        {
            if (boxIfPlayerNo.Checked == true) boxIfPlayerYes.Checked = false;
        }

        private void boxWhichPlayerRare_CheckedChanged(object sender, EventArgs e)
        {
            if (boxWhichPlayerRare.Checked == true)
            {
                boxWhichPlayerCasual.Checked = false;
                boxWhichPlayerManiac.Checked = false;
            }
        }

        private void boxWhichPlayerCasual_CheckedChanged(object sender, EventArgs e)
        {
            if (boxWhichPlayerCasual.Checked == true)
            {
                boxWhichPlayerRare.Checked = false;
                boxWhichPlayerManiac.Checked = false;
            }
        }

        private void boxWhichPlayerManiac_CheckedChanged(object sender, EventArgs e)
        {
            if (boxWhichPlayerManiac.Checked == true)
            {
                boxWhichPlayerCasual.Checked = false;
                boxWhichPlayerRare.Checked = false;
            }
        }

        private void checkIfUserAnswered() //this function checks if any of possible answers is checked. If not user cannot go to the next question
        {
            if (whichQuestion == 0 && boxIfTakenYes.Checked == false && boxIfTakenNo.Checked == false) whichQuestion = -1;
            if (whichQuestion == 1 && boxTravelByAuto.Checked == false && boxTravelByPublic.Checked == false) whichQuestion = 0;
            if (whichQuestion == 2 && boxIfUseYes.Checked== false && boxIfUseNo.Checked == false) whichQuestion = 1;
            if (whichQuestion == 3 && boxIfGraphicYes.Checked == false && boxIfGraphicNo.Checked == false) whichQuestion = 2;
            if (whichQuestion == 4 && boxIfGraphicJobYes.Checked == false && boxIfGraphicJobNo.Checked == false) whichQuestion = 3;
            if (whichQuestion == 5 && boxIfDesignerYes.Checked == false && boxIfDesignerNo.Checked == false) whichQuestion = 4;
            if (whichQuestion == 6 && boxIfDesignerJobYes.Checked == false && boxIfDesignerJobNo.Checked == false) whichQuestion = 5;
            if (whichQuestion == 7 && boxIfPlayerYes.Checked == false && boxIfPlayerNo.Checked == false) whichQuestion = 6;
            if (whichQuestion == 8 && boxWhichPlayerRare.Checked == false && boxWhichPlayerCasual.Checked == false && boxWhichPlayerManiac.Checked == false) whichQuestion = 7;
        }

        private void showSummary()
        {
            this.Hide();
            Form3 frm3 = new Form3();
            frm3.Show();
        }
    }
}

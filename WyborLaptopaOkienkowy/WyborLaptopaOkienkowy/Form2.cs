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
        private readonly string[] questions = new string[9];
        List<Panel> panels = new List<Panel>();
        int whichQuestion = 0;
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
            questions[0] = "Czy zabierasz swojego laptopa w podróże?";
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

        private void setQuestion()
        {
            textBox1.Text = questions[whichQuestion];
        }

        private void setAnswers()
        {
            foreach (var panel in panels)
            {
                panel.Visible = false;
            }
            panels[whichQuestion].Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkAnswer();
            whichQuestion++;
            if (whichQuestion == 9) whichQuestion = 0;
            setQuestion();
            setAnswers();
        }

        private void checkAnswer()
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
    }
}

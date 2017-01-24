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
        private readonly string[] questions = new string[9];//inicjalizacja tablicy zawierającej zestaw pytań
        private readonly string[] hints = new string[9]; //inicijalizacja tablicy zawierającej wskazówki dla użytkownika
        List<Panel> panels = new List<Panel>(); //utworzenie listy paneli zawierających możliwe odpowiedzi
        private int whichQuestion = 0; //licznik pytań, zaczynamy zadawanie od pierszego elementu tablicy
        private static string size; //rozmiar laptopa
        private static string weight; //waga laptopa
        private static string processorPerformance; //wydajność procesora
        private static string graphicPerformance; //wydajność karty graficznej
        private static string SSD; //czy ma być dysk SSD?
        private static string RAM; //ile pamięci RAM
        private static string diskSpace; //pojemność dysku (SSD + HDD)

        //gettery do parametrów laptopa
        public static string getSize() 
        {
            return size;
        }

        public static string getWeight()
        {
            return weight;
        }

        public static string getProcessorPerformance()
        {
            return processorPerformance;
        }

        public static string getGraphicPerformance()
        {
            return graphicPerformance;
        }

        public static string getSSD()
        {
            return SSD;
        }

        public static string getRAM()
        {
            return RAM;
        }

        public static string getDiskSpace()
        {
            return diskSpace;
        }
        //konstruktor drugiego okna
        public Form2()
        {
            InitializeComponent();
            //wypełniamy tablicę pytań
            questions[0] = "Czy zabierasz swojego laptopa w podróże?";
            questions[1] = "Czy podróżujesz autem, czy komunikacją publiczną?";
            questions[2] = "Czy korzystasz z laptopa w podróży?";
            questions[3] = "Czy zajmujesz się obróbką grafiki 2D i zdjęć hobbystycznie lub zawodowo?";
            questions[4] = "Czy to Twój zawód?";
            questions[5] = "Czy zajmujesz się projektowaniem modelowaniem 3D lub projektowaiem CAD/CAM?";
            questions[6] = "Czy to Twój zawód?";
            questions[7] = "Czy grasz w gry komputerowe?";
            questions[8] = "Określ swój stosunek do gier komputerowych:";
            //wypełniamy tablicę wskazówek
            hints[0] = "Zaznacz 'Tak', jeśli zabierasz ze sobą laptopa w podróże na tyle często, że jego rozmiar lub waga może wpływać na twoją satysfakcję z jego użytkowania.";
            hints[1] = "Podróż z laptopem autem sprawia, że mniejsze znaczenie ma jego waga. Zaznacz tę opcję, jeśli nie jest ona dla Ciebie ważna. Jednakże, jeśli często korzystasz z komunikacji publicznej warto ograniczyć wagę komputera. Zaznacz wtedy opcję 'Komunikacja publiczna'.";
            hints[2] = "Korzystanie z laptopa w podróży może być niewygodne, ze względu ograniczoną przestrzeń w samochodzie/komunikacji publicznej. Te pytanie ma wpływ na rozmiar dobieranego dla Ciebie laptopa.";
            hints[3] = "Zaznacz 'Tak' jeśli chcesz by Twój komputer dobrze sprawował się w obróbce grafiki 2D i zdjęć.";
            hints[4] = "Jeśli obróbka grafiki 2D i zdjęć jest Twoim sposobem na życie, zalecanym jest byś zaznaczył opcję 'Tak'. Dzięki temu Twój komputer będzie posiadał mocniejszy procesor  większą ilość pamięci RAM, by sprostać Twoim wymaganiom.";
            hints[5] = "Jeśli wykorzystanie laptopa w modelowaniu 3D i w pracy z oprogramowaniem CAD/CAM jest dla Ciebie ważne, potrzebujesz przynajmniej średnio wydajnego układu graficznego. Zalecanym jest, byś zaznaczył opcję 'Tak'.";
            hints[6] = "Jeśli zarabiasz w ten sposób na życie, zaznacz 'Tak'. Parametry poszukiwanego laptopa zostaną dodatkowo podniesione.";
            hints[7] = "Zaznacz 'Tak', tylko jeśli ważne dla Ciebie jest, by Twój laptop nadawał się do gier komputerowych.";
            hints[8] = "Jeśli nie masz potrzeby grania we wszystkie gorące nowości zaznacz opcje 'Niedzielny gracz'. Jeśli zależy Ci na możliwości zagrania w większość tytułów wybierz opcje 'Zwykły gracz'. Natomiast jeśli musisz zagrać we wszystkie gry, jakich zapragniesz zaznacz 'Zapalony gracz'. W tej kategorii znajdziesz również prawdziwe potwory, które pozwolą Ci ujarzmić każdy tytuł.";
            textBox1.Text = questions[whichQuestion]; //wyświetl pytanie zgodne z licznikiem pytań
            textBox2.Text = hints[whichQuestion]; //wyświetl wskazówkę zgodną z licznikem wskazówek
            //wypełnij listę paneli panelami zawierającymi checkBoxy z możliwymi odpowiedziami
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

        public void setQuestion() //wyświetl dane pytanie
        {
            textBox1.Text = questions[whichQuestion];
        }

        public void setHint() //wyświetl wskazówkę do danego pytania
        {
            textBox2.Text = hints[whichQuestion];
        }

        public void setAnswers() //wyświetl panel z odpowiedzami do danego pytania
        {
            foreach (var panel in panels) //ukryj wszystkie panele
            {
                panel.Visible = false;
            }
            panels[whichQuestion].Visible = true; //pokaż odpowiedni panel
        }
        //metoda obsługująca kliknięcie przycisku "dalej", po kliknięciu wyświetl następne pytanie, lub rozpocznik wnioskowanie
        //jeśli użytkownik odpowiedział na wszystkie pytania
        private void button1_Click(object sender, EventArgs e)
        {
            checkIfUserAnswered();
            skipQuestion();
            if (whichQuestion < 8)
            {

                whichQuestion++;
                setQuestion();
                setHint();
                setAnswers();
            }
            else
            {
                button1.Text = "Zakończ ankietę";
                checkAnswers();
                showSummary();
            }
        }
        //metoda pomijająca wyświetlanie pytań, jeśli na pytanie poprzedzające dotyczące tej samej tematyki
        //użytkownik odpowiedział "nie"
        private void skipQuestion()
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
        //metoda sprawdzająca odpowiedzi na pytania i dobierająca na ich podstawie parametry laptopa
        private void checkAnswers()
        {
            textBox1.Text = "Zakończono ankietę, czekaj na wynik wnioskowania";
            if (boxIfTakenNo.Checked == true)
            {
                size = "all";
                weight = "all";
            }
            if (boxIfTakenYes.Checked == true && boxTravelByPublic.Checked == true)
            {
                weight = "below and equal 3 kg";
            }
            if (boxIfTakenYes.Checked == true && boxTravelByAuto.Checked == true)
            {
                weight = "all";
            }
            if (boxIfTakenYes.Checked == true && boxIfUseYes.Checked == true)
            {
                size = "below and equal 15,6";
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
                diskSpace = "below and equal 1000 GB";
                RAM = "below and equal 8 GB";
            }
            if ((boxIfDesignerYes.Checked == true && boxIfDesignerJobNo.Checked == true) || (boxIfPlayerYes.Checked == true && boxWhichPlayerRare.Checked == true))
            {
                processorPerformance = "medium";
                graphicPerformance = "medium";
                SSD = "no";
                diskSpace = "below and equal 1000 GB";
                RAM = "below and equal 8 GB";
            }
            if (boxIfGraphicYes.Checked == true && boxIfGraphicJobNo.Checked == true)
            {
                processorPerformance = "medium";
                graphicPerformance = "medium";
                SSD = "yes";
                diskSpace = "below and equal 1000 GB";
                RAM = "below and equal 8 GB";
            }
            if (boxIfPlayerYes.Checked == true && boxWhichPlayerCasual.Checked == true)
            {
                processorPerformance = "medium";
                graphicPerformance = "medium";
                SSD = "yes";
                diskSpace = "below and equal 1000 GB";
                RAM = "above 8 GB";
            }
            if (boxIfGraphicYes.Checked == true && boxIfGraphicJobYes.Checked == true)
            {
                processorPerformance = "high";
                if (graphicPerformance != "high") graphicPerformance = "medium";
                SSD = "yes";
                diskSpace = "below and equal 1000 GB";
                RAM = "above 8 GB";
            }
            if ((boxIfDesignerYes.Checked == true && boxIfDesignerJobYes.Checked == true) || (boxIfPlayerYes.Checked == true && boxWhichPlayerManiac.Checked == true))
            {
                processorPerformance = "high";
                graphicPerformance = "high";
                SSD = "yes";
                diskSpace = "above 1000 GB";
                RAM = "above 8 GB";
            }
        }
        //Metoda dbająca o to, by tylko jedna odpowiedź na dane pytanie była zaznaczona
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
        //Metoda sprawdzająca czy użytkownik udzielił odpowiedzi na pytanie, jeśli nie to po naciśnięciu przycisku "Dalej"
        //nie wyświetla się kolejne pytanie
        private void checkIfUserAnswered()
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
        //Metoda wywołująca okno z podsumowaniem
        private void showSummary()
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }
        //Metoda zamykająca aplikację po wyłączeniu okna
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

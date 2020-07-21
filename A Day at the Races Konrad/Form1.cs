using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races_Konrad
{
    public partial class Form1 : Form
    {
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Guy[] GuyArray = new Guy[3];
        Random MyRandomizer = new Random();
    
        public Form1()
        {
            InitializeComponent();


            GreyhoundArray[0] = new Greyhound() { MyPictureBox = pictureBox1, StartingPosition = pictureBox1.Left, RacetrackLength = racetrackPictureBox.Width - pictureBox1.Width, Randomizer = MyRandomizer };
            GreyhoundArray[1] = new Greyhound() { MyPictureBox = pictureBox2, StartingPosition = pictureBox2.Left, RacetrackLength = racetrackPictureBox.Width - pictureBox1.Width, Randomizer = MyRandomizer };
            GreyhoundArray[2] = new Greyhound() { MyPictureBox = pictureBox3, StartingPosition = pictureBox3.Left, RacetrackLength = racetrackPictureBox.Width - pictureBox1.Width, Randomizer = MyRandomizer };
            GreyhoundArray[3] = new Greyhound() { MyPictureBox = pictureBox4, StartingPosition = pictureBox4.Left, RacetrackLength = racetrackPictureBox.Width - pictureBox1.Width, Randomizer = MyRandomizer };

            GuyArray[0] = new Guy() { Name = "Joe", MyBet = null, Cash = 50, MyRadioButton = joeRadioButton, MyLabel = joeCashLabel };
            GuyArray[0].UpdateLabels();

            GuyArray[1] = new Guy() { Name = "Bob", MyBet = null, Cash = 75, MyRadioButton = bobRadioButton, MyLabel = bobCashLabel };
            GuyArray[1].UpdateLabels();

            GuyArray[2] = new Guy() { Name = "Al", MyBet = null, Cash = 45, MyRadioButton = alRadioButton, MyLabel = alCashLabel };
            GuyArray[2].UpdateLabels();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < GreyhoundArray.Length; i++)
            {
               if(timer1.Enabled) GreyhoundArray[i].Run();

                if (GreyhoundArray[i].Run() == true)
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    MessageBox.Show("Hound nr " + i + " has won the race");

                    GuyArray[0].Collect(i);
                    GuyArray[1].Collect(i);
                    GuyArray[2].Collect(i);

                    GuyArray[0].ClearBet();
                    GuyArray[1].ClearBet();
                    GuyArray[2].ClearBet();

                    GuyArray[0].UpdateLabels();
                    GuyArray[1].UpdateLabels();
                    GuyArray[2].UpdateLabels();

                    GreyhoundArray[0].TakeStartingPosition();
                    GreyhoundArray[1].TakeStartingPosition();
                    GreyhoundArray[2].TakeStartingPosition();
                    GreyhoundArray[3].TakeStartingPosition();
                    raceStartButton.Enabled = true;
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            if(GuyArray[0].MyBet==null && GuyArray[1].MyBet == null && GuyArray[2].MyBet == null)
            {
                MessageBox.Show("No one placed bet!");
            }
            else
            {
                timer1.Start();
                raceStartButton.Enabled = false;
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = joeRadioButton.Text;
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = bobRadioButton.Text;
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = alRadioButton.Text;
        }

        private void betButton_Click(object sender, EventArgs e)
        {
            if(joeRadioButton.Checked)
            {
                GuyArray[0].PlaceBet(Convert.ToInt32(moneyPicker.Value), Convert.ToInt32(dogPicker.Value));                
                joeCashLabel.Text=GuyArray[0].MyBet.GetDescription();
            }

            if (bobRadioButton.Checked)
            {
                GuyArray[1].PlaceBet(Convert.ToInt32(moneyPicker.Value), Convert.ToInt32(dogPicker.Value));
                GuyArray[1].MyBet.GetDescription();
                bobCashLabel.Text = GuyArray[1].MyBet.GetDescription();
            }

            if (alRadioButton.Checked)
            {
                GuyArray[2].PlaceBet(Convert.ToInt32(moneyPicker.Value), Convert.ToInt32(dogPicker.Value));
                GuyArray[2].MyBet.GetDescription();
                alCashLabel.Text = GuyArray[2].MyBet.GetDescription();

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

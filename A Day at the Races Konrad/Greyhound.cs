using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_Races_Konrad
{
    public class Greyhound
    {
        public int StartingPosition; // Where my PictureBox starts
        public int RacetrackLength; // How long the racetrack is
        public PictureBox MyPictureBox = null; // My PictureBox object 
        public int Location = 0; // My Location on the racetrack 
        public Random Randomizer; // An instance of Random
        public bool Winner = false;

        public bool Run()
        {
            int move = Randomizer.Next(1, 20);
            Location = Location + move;//lokacja to przemieszczenie-biezaca lokalizacja+losowy ruch
            MyPictureBox.Left = StartingPosition + Location;//przesuwamy obrazek od starting posiiton o coraz wieksze przemieszczenie

            if (MyPictureBox.Left >= RacetrackLength)//jeśli wygrał
            {
                Winner = true;
                return true;
            }
            else
            {
                return false;
            }

        }
        
        
        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = StartingPosition;


        }
    }
}

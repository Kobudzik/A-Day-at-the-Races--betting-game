using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Day_at_the_Races_Konrad
{
    public class Bet
    {
        public int Amount; // The amount of cash that was bet 
        public int Dog; // The number of the dog the bet is on 
        public Guy Bettor; // The guy who placed the bet



        public string GetDescription()         // Return a string that says who placed the bet, how much 
                                               // cash was bet, and which dog he bet on
                                               //If the amount is zero, no bet was placed 
        {
            if (Amount == 0)
                return Bettor.Name + "hasn't placed a bet";
            else if(Bettor.Cash==0)
            {
                return Bettor.Name + "doesn't have enough money!";
            }
            else
                return Bettor.Name + " placed a bet of " + Amount + " money on " + Dog;
        }

        public int PayOut(int Winner)        // The parameter is the winner of the race.
                                             //If the dog won,  return the amount bet. Otherwise, return the negative of  the amount bet.  
        {
            if (Winner == Dog)
                return Amount;
            else
                return (0 - Amount);
        }

    }
 
}

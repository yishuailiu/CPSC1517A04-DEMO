using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Turn1 // make this public
    {
        public int Player1 { get; set; }
        public int Player2 { get; set; }

        //optionally, for practice only, add constructors
        public Turn1() //default constructer
        {
            
        }
        
        public Turn1( int player1, int player2) //default construcor
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}

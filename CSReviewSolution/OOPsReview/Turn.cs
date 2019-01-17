using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    class Turn
    {
        private int _Side;
        private string _Color;
        private Die _player1;
        private Die _player2;

        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                if (/*value.Trim() == "" || value == null is the same thing to string.IsNullOrWhiteSpace or */ string.IsNullOrEmpty(value))
                {
                    throw new Exception("color wrong");
                }
                else
                {
                    _Color = value;
                }
            }
        }
        public int Side //question means that this properties can be null. 
        {
            get
            {
                //returns data of a specific datatype
                return _Side;
            }
            set
            {
                //assigns a supplied value to the data member
                if (value >= 6 && value <= 20)
                {
                    _Side = value;                    
                }
                else
                {
                    throw new Exception("wrong, cant be" + value.ToString() + "sided");
                }

            }
        }

        public Turn (int side, string color)
        {
            Side = side;
            Color = color;
            _player1 = new Die(_Side, _Color);
            _player2 = new Die(_Side, _Color);
        }

        public void Result()
        {
            Console.WriteLine("Player 1 got {0}, Player 2 got {1}. ", _player1.FaceValue, _player2.FaceValue);
            if (_player1.FaceValue > _player2.FaceValue)
            {
                Console.WriteLine("Player 1 wins.");
            }
            else
            {
                if (_player2.FaceValue > _player1.FaceValue)
                {
                    Console.WriteLine("Player 2 wins.");
                }
                else
                {
                    Console.WriteLine("Draw.");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_02_4640_4825
{
    enum E_Color{ red=0, black}

    class Card:IComparable
    {
        //members
        private E_Color Color;
        private int Number;

        //consrtuctors
        public Card() { }
        public Card(E_Color C, int N) { Color = C; Number = N; }

        //properties
        public E_Color Clr
        {
            get { return Color; }
            set { Color = value; }
        }
        public int Num
        {
            get { return Number; }
            set
            {
                if (value>=2 && value<=14)
                    Number = value;
            }
        }
        public String CardName
        {
            get
            {
                if (int.Parse(Value) >= 2 && int.Parse(Value) <= 10)
                    return CardName;
                if (int.Parse(Value) == 11)
                    return "Jack";
                if (int.Parse(Value) == 12)
                    return "Queen";
                if (int.Parse(Value) == 13)
                    return "King";
                if (int.Parse(Value) == 14)
                    return "Ace";
                return "ERROR";
            }
        }
        public string Value { get; private set; }
        
        //functions

        //compare two cards in order to sort the package
        //this fuction is practice the interface IComperable
        public int CompareTo(object obj)
        {
            Card c = (Card)obj;
            return Number.CompareTo(c.Number);
        }

        //ToString
        public override string ToString()
        {
            return " " + Number + " of " + Color + " ";
        }
    }
 
}

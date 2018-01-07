using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_02_4640_4825
{
    class CardStock
    {
        //members
        List<Card> Cards;

        //constructor
        public CardStock()
        {
            Cards = new List<Card>();
            //calls function to add cards
            NewCards(Cards);
        }

        //functions

        //this function called by the constructor
        private static void NewCards(List<Card> Cards)
        {
            //add sorted cards to the package
            for (int i = 2; i <= 14; i++)
            {
                Cards.Add(new Card(E_Color.red, i));
                Cards.Add(new Card(E_Color.black, i));
            }

        }

        //mixing the cards
        public void Mix()
        {
            Random r1 = new Random();
            Random r2 = new Random();

            //temporary array to swap the cards
            Card[] x;

            //copying all the values from the queue "PlayersCards" to the array "x"
            x = Cards.ToArray();

            //here mixing
            int a = 26;
            while (a > 0)
            {
                int i = r1.Next(0, 26);
                int j = r2.Next(0, 26);
                //swap
                Card temp = x[i];
                x[i] = x[j];
                x[j] = temp;
                //decrease the value of the index
                a--;
            }

            //copying back all the values from the array "x" to the queue "PlayersCards"
            for (int i = 0; i < 26; i++)
            {
                Cards.Remove(x[i]);
            }
        }

        //ToString
        public override string ToString()
        {
            string str = null;
            for (int i = 0; i < 26; i++)
            {
                str += Cards[i].ToString() + " ";

            }
            return str;
        }

        //distribute cards to the players
        public void Distribute(params Player[] players)
        {
            int numplayer = players.Count();
            int numofcards = Cards.Count;
            int num = numofcards / numplayer;
            int j = 0;
            foreach (Player p in players)
            {
                for (int i = 0; i < num; i++)
                {
                    //goes to the function AddCard in player
                    p.AddCard(Cards[j++]);
                }
            }
        }

        //indexer
        public Card this[String index]
        {
            get
            {
                for(int i=0; i<Cards.Count();i++)
                {
                    if (index == Cards[i].CardName)
                    {
                        return Cards[i];
                    }
                }
                return null;
            }
            set { }
        }

        //sorting the package
        public List<Card> Sort()
        {
            List<Card> temp = new List<Card>();
            for (int i = 0; i < 26; i++)
            {
                temp.Add(null);
            }
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Clr == E_Color.red)
                {
                    int number = Cards[i].Num;
                    temp[number - 2] = new Card(Cards[i].Clr, Cards[i].Num);

                }
                if (Cards[i].Clr == E_Color.black)
                {
                    int number = Cards[i].Num;
                    temp[number + 11] = new Card(Cards[i].Clr, Cards[i].Num);

                }
            }
            Cards = temp;
            return Cards;
        }

        //adding card to the CardStock
        public void AddCard(Card crd)
        {
            Cards.Add(crd);
        }

        //removing card from the CardStock
        public void RemoveCard(Card crd)
        {
            Cards.Remove(crd);

        }
    }
}

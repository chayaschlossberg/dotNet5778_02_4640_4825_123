using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_02_4640_4825
{
    class Player
    {
        //members
        private String Name;
        public Queue<Card> PlayersCards;

        //constructor
        public Player() { }

        public Player(string n)
        {
            Name = n;
            PlayersCards = new Queue<Card>();
        }

        //properties for Name
        public String Namepro
        {
            get { return Name; }
            set { Name = value; }
        }

        //functions
        
        //add cards to the end of the queue
        public void AddCard(params Card[] cards)
        {
            for (int i=0; i<cards.Length;i++)
            {
                //add cards to the queue
                PlayersCards.Enqueue(cards[i]);
            }

        }
        
        //ToString
        public override string ToString()
        {
            Card x;
            string str = null;
            Queue<Card> copyCard = PlayersCards;
            for (int i = 0; i < PlayersCards.Count; i++)
            {
                x = copyCard.Dequeue();
                str += x.CardName + " ,";
            }
            return "name of player: " + Name + "\n number of cards: " + PlayersCards.Count + "\n  cards number" + str;

        }
        
        //check if the player is lost
        public bool Lose()
        {
            //if the queue is empty return true
            return PlayersCards.Count == 0;
        }

        //taking away the top card
        public Card Pop()
        {
            if (!Lose())
                return PlayersCards.Dequeue();
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_02_4640_4825
{
    class Game
    {
        //members
        public CardStock cardStock;
        public Player player1;
        public Player player2;

        //constructor
        public Game(string p1, string p2)
        {
            cardStock = new CardStock();
            player1 = new Player(p1);
            player2 = new Player(p2);
            cardStock.Mix();
            cardStock.Distribute(player1, player2);
        }

        //functions
        //this function returns the winner's name
        public string Winner()
        {
            if (player1.Lose() == true)
            {
                return player2.Namepro;
            }
            if (player2.Lose() == true)
            {
                return player1.Namepro;
            }
            return "no one won";
        }

        //check for gameover
        public bool gameOver()
        {
            if (player1.Lose() == true || player2.Lose() == true)
            {
                return true;
            }
            return false;
        }

        //ToString
        public override string ToString()
        {
            return "name of player1: " + player1.Namepro + " his number of cards: " + player1.PlayersCards.Count + "\n" +
                   "name of player2: " + player2.Namepro + " his number of cards: " + player2.PlayersCards.Count + "\n";
        }

        //here we play:
        //two players put a card and check who has to get it
        //there is option for same card
        public void Step()
        {
            Card card1 = player1.Pop();
            Card card2 = player2.Pop();
            if (player1.Lose() == true || player2.Lose() == true)
            { return; }
            if (card1.CompareTo(card2) == 1)
            {
                player2.AddCard(card1, card2);
            }
            if (card1.CompareTo(card2) == -1)
            {
                player1.AddCard(card1, card2);
            }
            if (card1.CompareTo(card2) == 0)
            {
                Card[] arrayCards = new Card[26];
                arrayCards[0] = card1;
                arrayCards[1] = card2;
                if (player1.PlayersCards.Count >= 2 && player2.PlayersCards.Count >= 2)
                {
                    arrayCards[2] = player1.Pop();
                    arrayCards[3] = player2.Pop();
                    card1 = player1.Pop();
                    card2 = player2.Pop();

                    if (card1.CompareTo(card2) == 1)
                    {
                        player2.AddCard(card1, card2);
                        player2.AddCard(arrayCards);
                    }
                    if (card1.CompareTo(card2) == -1)
                    {
                        player1.AddCard(card1, card2);
                        player1.AddCard(arrayCards);
                    }
                }
            }
        }
    }
}

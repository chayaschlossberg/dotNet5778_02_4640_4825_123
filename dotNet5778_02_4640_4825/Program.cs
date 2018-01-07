//Ora Partouce 206674640 
//Chaya Schlossberg 206074825
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_02_4640_4825
{
    class Program
    {
        static void Main(string[] args)
        {
            //designing the console window
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            //start the game
            Console.WriteLine("enter 2 names of players:\n");
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            Game g = new Game(a, b);

            CardStock card = new CardStock();
            g.Step();
            Console.WriteLine(g.Winner());

            Console.WriteLine(card.ToString());
            Console.WriteLine(g.player1.ToString());
            Console.WriteLine(g.player2.ToString());


        }
    }
}

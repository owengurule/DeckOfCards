using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            deck.Shuffle();
            Player player = new Player("Owen", deck.Deal(5));
            Player player2 = new Player("Kris", deck.Deal(5));

            int i = 0;
            while (player.CheckHand() < PokerHand.FourOfAKind || player2.CheckHand() < PokerHand.FourOfAKind)
            {
                if (deck.Cards.Count() < 5)
                {
                    deck.Shuffle();
                }
                player = new Player("Owen", deck.Deal(5));
                if (deck.Cards.Count() < 5)
                {
                    deck.Shuffle();
                }
                player2 = new Player("Kris", deck.Deal(5));
                var x = player2.CheckHand();
                var y = player.CheckHand();
                if (player.CheckHand() == PokerHand.FourOfAKind || player2.CheckHand() == PokerHand.FourOfAKind)
                {
                    i++;
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine(player.GetHand() + "\n" + player2.GetHand());
            Console.WriteLine(player.Name + " has a "+player.CheckHand()+"\n");
            Console.WriteLine(player2.Name+" has a "+player2.CheckHand());
            Console.ReadKey();
        }
    }
}

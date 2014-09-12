using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{

    enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    enum Suit
    {
        Club,
        Spade,
        Heart,
        Diamond
    }

    class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Suit s, Rank r)
        {

            this.Suit = s;
            this.Rank = r;

        }

        public string GetCardInfo()
        {

            return this.Rank + " of " + this.Suit;
        }
    }
}

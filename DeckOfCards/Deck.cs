using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Deck
    {
        public List<Card> Cards { get; set; }
        public List<Card> DealtCards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
            DealtCards = new List<Card>();
            for (int i = 1; i <= 52; i++)
            {

                int suitCounter = i % 4;
                int rankCounter = i % 13 + 2;
                Suit s = (Suit)suitCounter;
                Rank r = (Rank)rankCounter;
                Card tmp = new Card(s, r);
                Cards.Add(tmp);
            }
        }


        public void Shuffle()
        {
            this.Cards.AddRange(DealtCards);
            this.DealtCards.Clear();
            Random rng = new Random();
            for (int i = 0; i < this.Cards.Count; i++)
            {
                int k = rng.Next(i, Cards.Count);
                Card tmp = Cards[k];
                this.Cards[k] = this.Cards[i];
                this.Cards[i] = tmp;
            }

        }

        public List<Card> Deal(int x)
        {
            List<Card> Hand = new List<Card>();

            for (int i = 0; i < x; i++)
            {
                Hand.Add(this.Cards.First());
                this.DealtCards.Add(this.Cards.First());
                this.Cards.Remove(this.Cards.First());
            }
            return Hand;
        }

    }
}

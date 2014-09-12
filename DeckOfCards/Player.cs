using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{

    enum PokerHand
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }

    class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
        public PokerHand PokerHand { get; set; }

        public Player(string n, List<Card> h)
        {
            this.Name = n;
            this.Hand = h;
        }

        public PokerHand CheckHand()
        {
            PokerHand pHand = PokerHand;
            var groups = this.Hand.GroupBy(x => x.Rank);
            bool hasPair = false;
            bool hasTwoPair = false;
            bool hasThree = false;
            bool isFlush = false;
            bool isStraight = false;

            int HighCard = (int)this.Hand.OrderByDescending(x => x.Rank).Select(x => x.Rank).First();
            foreach (var group in groups)
            {
               if(!hasPair && group.Count() == 2)
               {
                   hasPair = true;
               }
               if (hasPair && group.Count() == 2)
               {
                   hasPair = false;
                   hasTwoPair = true;
               }
               if (!hasTwoPair && group.Count() == 3)
               {
                   hasThree = true;
               }
               if (hasTwoPair && group.Count() == 3)
               {
                   hasPair = false;
                   hasThree = false;
                   pHand = PokerHand.FullHouse;
               }
               if (group.Count() == 4)
               {
                   hasPair = false;
                   hasTwoPair = false;
                   pHand = PokerHand.FourOfAKind;
               }
              
            }
            if (this.Hand.Select(x => x.Suit).Distinct().Count() == 1)
            {
                isFlush = true;
            }
            List<Rank> ordered = Hand.OrderByDescending(x => x.Rank).Select(x => x.Rank).ToList();
            if (ordered.First() - ordered.Last() == 4)
            {
                isStraight = true;
            }
            if (isFlush && isStraight)
            {
                if (HighCard == 14)
                {
                    pHand = PokerHand.RoyalFlush;
                }
                else
                {
                    pHand = PokerHand.StraightFlush;
                }


            }

            if (!isFlush && isStraight)
            {
                pHand = PokerHand.Straight;

            }
            if (isFlush && !isStraight)
            {
                pHand = PokerHand.Flush;
            }
            if (hasPair)
            {
                pHand = PokerHand.OnePair;
            }
            else if (hasTwoPair)
            {
                pHand = PokerHand.TwoPair;
            }
            else if (hasThree)
            {
                pHand = PokerHand.ThreeOfAKind;
            }
            else
            {
                pHand = PokerHand.HighCard;
            }

            return pHand;

        }

        public string GetHand()
        {
            return this.Name + ": " + string.Join(" - ", this.Hand.Select(x => x.GetCardInfo()));
        }
    }
}

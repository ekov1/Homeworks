using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand?.Cards.Count != 5)
            {
                return false;
            }

            var sortedHand = hand.Cards
                .OrderBy(x => x.Face)
                .ThenBy(x => x.Suit)
                .ToList();

            var curentCard = sortedHand[0];
            for (int i = 1; i < sortedHand.Count; i++)
            {
                if (curentCard.Face == sortedHand[i].Face && curentCard.Suit == sortedHand[i].Suit)
                {
                    return false;
                }
                curentCard = sortedHand[i];
            }
            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var currCard = hand.Cards[0];
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                var biggerCardFace = (int)currCard.Face > (int)hand.Cards[i].Face ? (int)currCard.Face : (int)hand.Cards[i].Face;
                var smallerCardFace = (int)currCard.Face < (int)hand.Cards[i].Face ? (int)currCard.Face : (int)hand.Cards[i].Face;

                if (currCard.Suit != hand.Cards[i].Suit ||
                    smallerCardFace + 1 != biggerCardFace)
                {
                    return false;
                }
                currCard = hand.Cards[i];
            }
            return true;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var result = hand.Cards
                .GroupBy(x => x.Face)
                .Count(x => x.Count() == 4);

            return result == 1 ? true : false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var result = hand.Cards
                .GroupBy(x => x.Suit)
                .Count(x => x.Count() == 5);

            if (this.IsStraightFlush(hand))
            {
                return false;
            }

            return result == 1 ? true : false;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}

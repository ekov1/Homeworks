namespace Poker.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class PokerHandsCheckerTests
    {
        private PokerHandsChecker checker = new PokerHandsChecker();

        private Hand validHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds)
            });

        private Hand handWithMoreThan5Cards = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds)
            });

        private Hand handWithLessCards = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds)
            });

        private Hand twoEqualCardsHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

        private Hand flushHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
            });

        private Hand straightFlushHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

        private Hand differentSuitCardsHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
            });

        private Hand fourOfAKindHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            });

        [Test]
        public void IsValidHand_InputHandWith5DifferentCards_ShouldReturnTrueValue()
        {
            Assert.IsTrue(this.checker.IsValidHand(this.validHand));
        }

        [Test]
        public void IsValidHand_CheckIfHandWithTwoEqualCardsIsValid_ShouldReturnFalseValue()
        {
            Assert.IsFalse(this.checker.IsValidHand(this.twoEqualCardsHand));
        }

        [Test]
        public void IsValidHand_InputNullHand_ShouldReturnFalseValue()
        {
            Assert.IsFalse(this.checker.IsValidHand(null));
        }

        [Test]
        public void IsValidHand_InputHandWithLessThan5Cards_ShouldReturnFalseValue()
        {
            Assert.IsFalse(this.checker.IsValidHand(this.handWithLessCards));
        }

        [Test]
        public void IsValidHand_InputHandWithMoreThan5Cards_ShouldReturnFalseValue()
        {
            Assert.IsFalse(this.checker.IsValidHand(this.handWithMoreThan5Cards));
        }

        [Test]
        public void IsFlush_InputValidFlushHand_ShouldReturnTrueValue()
        {

            Assert.IsTrue(this.checker.IsFlush(this.flushHand));
        }

        [Test]
        public void IsFlush_InputInvalidHandWith2EqualCards_ShouldReturnFalseValue()
        {
            Assert.IsFalse(this.checker.IsFlush(this.twoEqualCardsHand));
        }

        [Test]
        public void IsFlush_InputDifferentSuitCards_ShouldReturnFalseValue()
        {
            Assert.IsFalse(this.checker.IsFlush(this.differentSuitCardsHand));
        }

        [Test]
        public void IsFlush_InputStraightFlushHand_ShouldReturnFalseValue()
        {
            Assert.IsFalse(this.checker.IsFlush(this.straightFlushHand));
        }

        [Test]
        public void IsStraightFlush_InputStraightFlushHand_ShouldReturnTrueValue()
        {
            Assert.IsTrue(this.checker.IsStraightFlush(this.straightFlushHand));
        }

        [Test]
        public void IsStraightFlush_CheckIfHandWithTwoEqualCardsIsValid_ShouldReturnFalseValue()
        {
            Assert.IsFalse(this.checker.IsStraightFlush(this.twoEqualCardsHand));
        }

        [Test]
        public void ISFourOfAKind_InputFourOfAKingHand_ShouldReturnTrueValue()
        {
            Assert.IsTrue(this.checker.IsFourOfAKind(this.fourOfAKindHand));
        }

        [Test]
        public void IsFourOfAKind_InputHandWithMoreThan5Cards_ShouldReturnFalseValue()
        {
            Assert.IsFalse(this.checker.IsFourOfAKind(this.twoEqualCardsHand));
        }
    }
}

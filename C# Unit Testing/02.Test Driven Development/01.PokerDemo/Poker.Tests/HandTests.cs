namespace Poker.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class HandTests
    {
        [Test]
        public void Hand_TestToStringMethod_ShouldReturnProperToStringImplementation()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Hearts)
            });

            var expectedResult = "Hand: Ace of Clubs, Four of Hearts";

            Assert.AreEqual(expectedResult, hand.ToString());
        }

        [Test]
        public void Hand_TestToStringMethodWithNoCardsInHand_ShouldReturnHandWithNoCards()
        {
            var hand = new Hand(new List<ICard>());

            var expectedResult = "No cards in hand!";

            Assert.AreEqual(expectedResult, hand.ToString());
        }
    }
}

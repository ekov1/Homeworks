namespace Poker.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class CardTests
    {
        [Test]
        public void Card_TestToStringMethod_ShouldReturnProperToStringImplementation()
        {
            var card = new Card(CardFace.Five, CardSuit.Clubs);

            var expectedResult = "Five of Clubs";

            Assert.AreEqual(expectedResult, card.ToString());
        }
    }
}

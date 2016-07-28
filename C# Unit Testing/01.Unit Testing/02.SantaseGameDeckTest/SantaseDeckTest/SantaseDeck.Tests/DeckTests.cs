namespace SantaseDeck.Tests
{
    using Logic;
    using NUnit.Framework;
    using Logic.Cards;

    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void Deck_GetCardNumber_ShouldReturnNumberOfCardsInDeck()
        {
            var deck = new Deck();
            var deckSize = 24;

            Assert.AreEqual(deckSize, deck.CardsLeft);
        }

        [Test]
        public void Deck_GetTrumpCard_ShouldReturnCorrectTrumpCard()
        {
            var deck = new Deck();
            var deckSize = 24;
            Card trCard = null;

            for (int i = 0; i < deckSize; i++)
            {
                trCard = deck.GetNextCard();
            }
            Assert.AreSame(trCard, deck.TrumpCard);
        }

        [TestCase(CardSuit.Club, CardType.Ace)]
        [TestCase(CardSuit.Diamond, CardType.Nine)]
        public void Deck_TestChangeTrumpCard_ShouldChangeTrumpCardCorrectly(CardSuit suit, CardType type)
        {
            var deck = new Deck();
            var card = new Card(suit, type);

            deck.ChangeTrumpCard(card);

            Assert.AreSame(card, deck.TrumpCard);
        }

        [Test]
        public void Deck_GetNextCardWithNoCardsInDeckLeft_ShouldThrowException()
        {
            var deck = new Deck();
            var deckSize = 24;

            for (int i = 0; i < deckSize; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }
    }
}

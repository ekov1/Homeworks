using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            if (this.Cards.Count == 0)
            {
                return "No cards in hand!";
            }

            StringBuilder builder = new StringBuilder();
            builder.Append("Hand:");
            for (int i = 0; i < this.Cards.Count; i++)
            {
                if (i == 0)
                {
                    builder.Append(" " + this.Cards[i].ToString());
                }
                else
                {
                    builder.Append(", " + this.Cards[i].ToString());
                }
            }

            return builder.ToString();
        }
    }
}

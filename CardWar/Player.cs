using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardWar
{
    public class Player
    {
        private List<Card> playHand = new List<Card>();
        private List<Card> discardPile = new List<Card>();

        public List<Card> PlayHand { get { return playHand; } }
        public List<Card> DiscardPile { get { return discardPile; } }

        public void AddCard(Card card)
        {
            discardPile.Add(card);
        }

        public int CardCount { get { return (playHand.Count + discardPile.Count); } }

        public Card DrawCard()
        {
            Debug.WriteLine("\nPlay Hand Size: " + playHand.Count);
            if (playHand.Count == 0)
            {
                shuffleDiscardPileAndAddToPlayHand();
            }

            Card cardToReturn = playHand[0];

            playHand.RemoveAt(0);

            Debug.WriteLine("Play Hand Size: " + playHand.Count);

            return cardToReturn;
        }

        private void shuffleDiscardPileAndAddToPlayHand()
        {
            if (discardPile.Count > 0)
            {
                Random random = new Random();

                while (discardPile.Count > 0)
                {
                    Debug.WriteLine("\nDiscard Pile Size: " + discardPile.Count + "\nPlay Hand Size: " + playHand.Count);
                    int cardToPull = random.Next(0, discardPile.Count - 1);

                    playHand.Add(discardPile[cardToPull]);
                    Debug.WriteLine("Pulling from discard pile: " + discardPile[cardToPull]);
                    discardPile.RemoveAt(cardToPull);

                    Debug.WriteLine("\nDiscard Pile Size: " + discardPile.Count + "\nPlay Hand Size: " + playHand.Count);
                }
            }

            else if ((discardPile.Count == 0) && (playHand.Count == 0))
            {
                throw new System.Exception("Player is out of cards");
            }
        }
    }
}

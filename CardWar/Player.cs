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

        public Card CheckCard()
        {
            if (playHand.Count == 0)
            {
                Debug.WriteLine("No cards in PlayHand. Trying to draw from DiscardPile.");
                shuffleDiscardPileAndAddToPlayHand();
            }

            Card cardToReturn = playHand[0];

            return cardToReturn;
        }

        public Card DrawCard()
        {
            Card cardToReturn = CheckCard();

            playHand.RemoveAt(0);

            Debug.WriteLine("DrawCard end. PlayHand count: " + playHand.Count + " DiscardPile count: " + discardPile.Count);

            return cardToReturn;
        }

        private void shuffleDiscardPileAndAddToPlayHand()
        {
            if (discardPile.Count > 0)
            {
                Random random = new Random();

                while (discardPile.Count > 0)
                {
                    Debug.WriteLine("\nDiscardPile count: " + discardPile.Count + "\nPlayHand Count: " + playHand.Count);
                    int cardToPull = random.Next(0, discardPile.Count - 1);

                    playHand.Add(discardPile[cardToPull]);
                    Debug.WriteLine("Pulling from discard pile: " + discardPile[cardToPull].FaceOfSuite);
                    discardPile.RemoveAt(cardToPull);

                    Debug.WriteLine("\nDiscardPile count: " + discardPile.Count + "\nPlayHand Count: " + playHand.Count);
                }
            }

            else if ((discardPile.Count == 0) && (playHand.Count == 0))
            {
                Debug.WriteLine("Player is out of cards");
                throw new System.Exception("Player is out of cards");
            }
        }
    }
}

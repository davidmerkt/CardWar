using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardWar
{
    public class CardCollection
    {
        private string name;
        private List<Card> drawPile = new List<Card>();
        private List<Card> discardPile = new List<Card>();

        public string Name { get { return name; } }
        public List<Card> DrawPile { get { return drawPile; } }
        public List<Card> DiscardPile { get { return discardPile; } }

        public CardCollection() { }

        public CardCollection(string name)
        {
            this.name = name;
        }

        public void AddCard(Card card)
        {
            discardPile.Add(card);
        }

        public int CountCard { get { return (drawPile.Count + discardPile.Count); } }

        public Card CheckCard()
        {
            if (drawPile.Count == 0)
            {
                Debug.WriteLine("No cards in PlayHand. Trying to draw from DiscardPile.");
                shuffleDiscardPileAndAddToPlayHand();
            }

            Card cardToReturn = drawPile[0];

            return cardToReturn;
        }

        public Card DrawCard()
        {
            Card cardToReturn = CheckCard();

            drawPile.RemoveAt(0);

            Debug.WriteLine("DrawCard end. PlayHand count: " + drawPile.Count + " DiscardPile count: " + discardPile.Count);

            return cardToReturn;
        }

        private void shuffleDiscardPileAndAddToPlayHand()
        {
            if (discardPile.Count > 0)
            {
                Random random = new Random();

                while (discardPile.Count > 0)
                {
                    Debug.WriteLine("\nDiscardPile count: " + discardPile.Count + "\nPlayHand Count: " + drawPile.Count);
                    int cardToPull = random.Next(0, discardPile.Count - 1);

                    drawPile.Add(discardPile[cardToPull]);
                    Debug.WriteLine("Pulling from discard pile: " + discardPile[cardToPull].FaceOfSuite);
                    discardPile.RemoveAt(cardToPull);

                    Debug.WriteLine("\nDiscardPile count: " + discardPile.Count + "\nPlayHand Count: " + drawPile.Count);
                }
            }

            else if ((discardPile.Count == 0) && (drawPile.Count == 0))
            {
                Debug.WriteLine("Player is out of cards");
                throw new System.Exception("Player is out of cards");
            }
        }
    }
}

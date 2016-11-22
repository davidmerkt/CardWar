using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardWar
{
    class Program
    {
        private static List<Card> p1HandDeck;
        private static List<Card> p1DiscardDeck;
        private static List<Card> p2HandDeck;
        private static List<Card> p2DiscardDeck;
        private static List<Card> cardDeck;

        static void Main(string[] args)
        {
            CreateNewDeck();
            DistributeNewCards();
            
            p1DiscardDeck = new List<Card>();
            p2DiscardDeck = new List<Card>();

            StartGame();

            Console.ReadLine();
        }        

        public static void DistributeNewCards()
        {
            p1HandDeck = new List<Card>();
            p2HandDeck = new List<Card>();

            Debug.WriteLine("Number of cards in cardDeck: " + cardDeck.Count);
            Debug.WriteLine("Number of cards in p1 hand: " + p1HandDeck.Count);
            Debug.WriteLine("Number of cards in p2 hand: " + p2HandDeck.Count);

            Random random = new Random();

            while (cardDeck.Count > 0)
            {

                int cardToPull = random.Next(0, cardDeck.Count - 1);

                if (cardDeck.Count % 2 == 0)
                {
                    p1HandDeck.Add(cardDeck[cardToPull]);
                    cardDeck.RemoveAt(cardToPull);
                }
                else
                {
                    p2HandDeck.Add(cardDeck[cardToPull]);
                    cardDeck.RemoveAt(cardToPull);
                }

                Debug.WriteLine("\nCard number to pull: " + cardToPull);
                Debug.WriteLine("Number of cards in cardDeck: " + cardDeck.Count);
                Debug.WriteLine("Number of cards in p1 hand: " + p1HandDeck.Count);
                Debug.WriteLine("Number of cards in p2 hand: " + p2HandDeck.Count);
            }
        }

        public static void PlayRound()
        {
            if ((p1HandDeck.Count > 0) && (p2HandDeck.Count > 0))
            {
                if (p1HandDeck[0].FaceValue > p2HandDeck[0].FaceValue)
                {
                    Console.WriteLine("Player 1's " + p1HandDeck[0].FaceOfSuite + " beats Player 2's " + p2HandDeck[0].FaceOfSuite);
                    p1DiscardDeck.Add(p1HandDeck[0]);
                    p1DiscardDeck.Add(p2HandDeck[0]);
                    p1HandDeck.RemoveAt(0);
                    p2HandDeck.RemoveAt(0);
                    ListCards(p1DiscardDeck);
                }

                if (p2HandDeck[0].FaceValue > p1HandDeck[0].FaceValue)
                {
                    Console.WriteLine("Player 2's " + p2HandDeck[0].FaceOfSuite + " beats Player 1's " + p1HandDeck[0].FaceOfSuite);
                    p2DiscardDeck.Add(p1HandDeck[0]);
                    p2DiscardDeck.Add(p2HandDeck[0]);
                    p1HandDeck.RemoveAt(0);
                    p2HandDeck.RemoveAt(0);
                    ListCards(p2DiscardDeck);
                }

                if (p2HandDeck[0].FaceValue == p1HandDeck[0].FaceValue)
                {
                    Console.WriteLine("Player 1's " + p1HandDeck[0].FaceOfSuite + " against Player 2's " + p2HandDeck[0].FaceOfSuite + " can only mean one thing: ");
                    Console.WriteLine("War‼");
                    Console.ReadLine();
                }
            }
        }

        public static void StartGame()
        {
            while ((p1HandDeck.Count > 0) || (p2HandDeck.Count > 0))
            {
                PlayRound();
            }
        }

        public static void ListCards(List<Card> cardList)
        {
            for (int i = 0; i < cardList.Count; i++)
            {
                Console.WriteLine(cardList[i].FaceOfSuite);
            }
        }

        public static void CreateNewDeck()
        {
            cardDeck = new List<Card>();

            Card clubTwo = new Card(Suite.Clubs, Face.Two);
            Card clubThree = new Card(Suite.Clubs, Face.Three);
            Card clubFour = new Card(Suite.Clubs, Face.Four);
            Card clubFive = new Card(Suite.Clubs, Face.Five);
            Card clubSix = new Card(Suite.Clubs, Face.Six);
            Card clubSeven = new Card(Suite.Clubs, Face.Seven);
            Card clubEight = new Card(Suite.Clubs, Face.Eight);
            Card clubNine = new Card(Suite.Clubs, Face.Nine);
            Card clubTen = new Card(Suite.Clubs, Face.Ten);
            Card clubJack = new Card(Suite.Clubs, Face.Jack);
            Card clubQueen = new Card(Suite.Clubs, Face.Queen);
            Card clubKing = new Card(Suite.Clubs, Face.King);
            Card clubAce = new Card(Suite.Clubs, Face.Ace);

            Card diamondTwo = new Card(Suite.Diamonds, Face.Two);
            Card diamondThree = new Card(Suite.Diamonds, Face.Three);
            Card diamondFour = new Card(Suite.Diamonds, Face.Four);
            Card diamondFive = new Card(Suite.Diamonds, Face.Five);
            Card diamondSix = new Card(Suite.Diamonds, Face.Six);
            Card diamondSeven = new Card(Suite.Diamonds, Face.Seven);
            Card diamondEight = new Card(Suite.Diamonds, Face.Eight);
            Card diamondNine = new Card(Suite.Diamonds, Face.Nine);
            Card diamondTen = new Card(Suite.Diamonds, Face.Ten);
            Card diamondJack = new Card(Suite.Diamonds, Face.Jack);
            Card diamondQueen = new Card(Suite.Diamonds, Face.Queen);
            Card diamondKing = new Card(Suite.Diamonds, Face.King);
            Card diamondAce = new Card(Suite.Diamonds, Face.Ace);

            Card heartTwo = new Card(Suite.Hearts, Face.Two);
            Card heartThree = new Card(Suite.Hearts, Face.Three);
            Card heartFour = new Card(Suite.Hearts, Face.Four);
            Card heartFive = new Card(Suite.Hearts, Face.Five);
            Card heartSix = new Card(Suite.Hearts, Face.Six);
            Card heartSeven = new Card(Suite.Hearts, Face.Seven);
            Card heartEight = new Card(Suite.Hearts, Face.Eight);
            Card heartNine = new Card(Suite.Hearts, Face.Nine);
            Card heartTen = new Card(Suite.Hearts, Face.Ten);
            Card heartJack = new Card(Suite.Hearts, Face.Jack);
            Card heartQueen = new Card(Suite.Hearts, Face.Queen);
            Card heartKing = new Card(Suite.Hearts, Face.King);
            Card heartAce = new Card(Suite.Hearts, Face.Ace);


            Card spadeTwo = new Card(Suite.Spades, Face.Two);
            Card spadeThree = new Card(Suite.Spades, Face.Three);
            Card spadeFour = new Card(Suite.Spades, Face.Four);
            Card spadeFive = new Card(Suite.Spades, Face.Five);
            Card spadeSix = new Card(Suite.Spades, Face.Six);
            Card spadeSeven = new Card(Suite.Spades, Face.Seven);
            Card spadeEight = new Card(Suite.Spades, Face.Eight);
            Card spadeNine = new Card(Suite.Spades, Face.Nine);
            Card spadeTen = new Card(Suite.Spades, Face.Ten);
            Card spadeJack = new Card(Suite.Spades, Face.Jack);
            Card spadeQueen = new Card(Suite.Spades, Face.Queen);
            Card spadeKing = new Card(Suite.Spades, Face.King);
            Card spadeAce = new Card(Suite.Spades, Face.Ace);

            cardDeck.Add(clubTwo);
            cardDeck.Add(clubThree);
            cardDeck.Add(clubFour);
            cardDeck.Add(clubFive);
            cardDeck.Add(clubSix);
            cardDeck.Add(clubSeven);
            cardDeck.Add(clubEight);
            cardDeck.Add(clubNine);
            cardDeck.Add(clubTen);
            cardDeck.Add(clubJack);
            cardDeck.Add(clubQueen);
            cardDeck.Add(clubKing);
            cardDeck.Add(clubAce);
            cardDeck.Add(diamondTwo);
            cardDeck.Add(diamondThree);
            cardDeck.Add(diamondFour);
            cardDeck.Add(diamondFive);
            cardDeck.Add(diamondSix);
            cardDeck.Add(diamondSeven);
            cardDeck.Add(diamondEight);
            cardDeck.Add(diamondNine);
            cardDeck.Add(diamondTen);
            cardDeck.Add(diamondJack);
            cardDeck.Add(diamondQueen);
            cardDeck.Add(diamondKing);
            cardDeck.Add(diamondAce);
            cardDeck.Add(heartTwo);
            cardDeck.Add(heartThree);
            cardDeck.Add(heartFour);
            cardDeck.Add(heartFive);
            cardDeck.Add(heartSix);
            cardDeck.Add(heartSeven);
            cardDeck.Add(heartEight);
            cardDeck.Add(heartNine);
            cardDeck.Add(heartTen);
            cardDeck.Add(heartJack);
            cardDeck.Add(heartQueen);
            cardDeck.Add(heartKing);
            cardDeck.Add(heartAce);
            cardDeck.Add(spadeTwo);
            cardDeck.Add(spadeThree);
            cardDeck.Add(spadeFour);
            cardDeck.Add(spadeFive);
            cardDeck.Add(spadeSix);
            cardDeck.Add(spadeSeven);
            cardDeck.Add(spadeEight);
            cardDeck.Add(spadeNine);
            cardDeck.Add(spadeTen);
            cardDeck.Add(spadeJack);
            cardDeck.Add(spadeQueen);
            cardDeck.Add(spadeKing);
            cardDeck.Add(spadeAce);
        }
    }
}

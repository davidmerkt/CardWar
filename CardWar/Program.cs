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
        private static CardCollection cardDeck;
        private static List<CardCollection> players;

        static void Main(string[] args)
        {
            CreateNewDeck();

            CreatePlayers(2);
            Debug.WriteLine("The number of players is: {0}", players.Count);

            DistributeNewCards();

            StartGame();

            Console.ReadLine();
        }        

        public static void DistributeNewCards()
        {
            DebugPrintCardsInEachPlayerHand();

            Random random = new Random();

            while (cardDeck.CountCard > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (cardDeck.CountCard == 0)
                        break;

                    players[i].AddCard(cardDeck.DrawCard());
                }

                DebugPrintCardsInEachPlayerHand();
            }
        }

        public static void StartGame()
        {
            while ((players[0].CountCard > 0) || (players[1].CountCard > 0))
            {
                PlayRound();
            }
        }

        public static void PlayRound()
        {
            List<CardCollection> playRoundVictor = new List<CardCollection>();

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].CountCard > 0)
                {
                    if (playRoundVictor.Count == 0)
                        playRoundVictor.Add(players[i]);

                    else if (players[i].CheckCard().FaceValue > playRoundVictor[0].CheckCard().FaceValue)
                    {
                        playRoundVictor.Clear();
                        playRoundVictor.Add(players[i]);
                        Debug.WriteLine("players[{0}] is the current holder of highest value card overturned", i);
                        Debug.WriteLine("The list size is {0}", playRoundVictor.Count);
                    }

                    else if (players[i].CheckCard().FaceValue == playRoundVictor[0].CheckCard().FaceValue)
                    {
                        playRoundVictor.Add(players[i]);
                        Debug.WriteLine("players[{0}] is added to the list of those competing in War", i);
                        Debug.WriteLine("The list size is {0}", playRoundVictor.Count);
                    }
                }
            }

            if (playRoundVictor.Count > 1)
            {
                Console.WriteLine("\nWar‼");
                War war = new War(playRoundVictor, players);
            }

            else
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].CountCard > 0)
                        playRoundVictor[0].AddCard(players[i].DrawCard());
                }
            }

            foreach (CardCollection player in players)
            {
                Console.WriteLine("Player {2}\n Cards in hand: {0} \n Cards in discard deck: {1}", player.DrawPile.Count, player.DiscardPile.Count, player.Name);
            }

            DebugPrintCardsInEachPlayerHand();
            Console.WriteLine("\n");
        }

        public static void DebugPrintCardsInEachPlayerHand()
        {
            for (int i = 0; i < players.Count; i++)
            {
                Debug.WriteLine("Number of cards in players[{0}] play hand: " + players[i].DrawPile.Count + "\nNumber of cards in players[{0}] discard hand: " + players[i].DiscardPile.Count, i);
            }
        }

        public static void ListCards(List<Card> cardList)
        {
            for (int i = 0; i < cardList.Count; i++)
            {
                Console.WriteLine(cardList[i].FaceOfSuite);
            }
        }

        public static void CreatePlayers(int numberOfPlayers)
        {
            players = new List<CardCollection>();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                string PlayerName = ("player" + i);
                players.Add(new CardCollection(PlayerName));
            }
        }

        public static void CreateNewDeck()
        {
            cardDeck = new CardCollection();

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

            cardDeck.AddCard(clubTwo);
            cardDeck.AddCard(clubThree);
            cardDeck.AddCard(clubFour);
            cardDeck.AddCard(clubFive);
            cardDeck.AddCard(clubSix);
            cardDeck.AddCard(clubSeven);
            cardDeck.AddCard(clubEight);
            cardDeck.AddCard(clubNine);
            cardDeck.AddCard(clubTen);
            cardDeck.AddCard(clubJack);
            cardDeck.AddCard(clubQueen);
            cardDeck.AddCard(clubKing);
            cardDeck.AddCard(clubAce);
            cardDeck.AddCard(diamondTwo);
            cardDeck.AddCard(diamondThree);
            cardDeck.AddCard(diamondFour);
            cardDeck.AddCard(diamondFive);
            cardDeck.AddCard(diamondSix);
            cardDeck.AddCard(diamondSeven);
            cardDeck.AddCard(diamondEight);
            cardDeck.AddCard(diamondNine);
            cardDeck.AddCard(diamondTen);
            cardDeck.AddCard(diamondJack);
            cardDeck.AddCard(diamondQueen);
            cardDeck.AddCard(diamondKing);
            cardDeck.AddCard(diamondAce);
            cardDeck.AddCard(heartTwo);
            cardDeck.AddCard(heartThree);
            cardDeck.AddCard(heartFour);
            cardDeck.AddCard(heartFive);
            cardDeck.AddCard(heartSix);
            cardDeck.AddCard(heartSeven);
            cardDeck.AddCard(heartEight);
            cardDeck.AddCard(heartNine);
            cardDeck.AddCard(heartTen);
            cardDeck.AddCard(heartJack);
            cardDeck.AddCard(heartQueen);
            cardDeck.AddCard(heartKing);
            cardDeck.AddCard(heartAce);
            cardDeck.AddCard(spadeTwo);
            cardDeck.AddCard(spadeThree);
            cardDeck.AddCard(spadeFour);
            cardDeck.AddCard(spadeFive);
            cardDeck.AddCard(spadeSix);
            cardDeck.AddCard(spadeSeven);
            cardDeck.AddCard(spadeEight);
            cardDeck.AddCard(spadeNine);
            cardDeck.AddCard(spadeTen);
            cardDeck.AddCard(spadeJack);
            cardDeck.AddCard(spadeQueen);
            cardDeck.AddCard(spadeKing);
            cardDeck.AddCard(spadeAce);
        }
    }
}

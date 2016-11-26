﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardWar
{
    class War
    {
        private List<Player> warriors;
        private List<Player> players;
        private List<Card> spoilsOfWar;
        private List<Player> warVictor;

        public War(List<Player> warriors, List<Player> playerList)
        {
            this.warriors = warriors;
            this.players = playerList;
            spoilsOfWar = new List<Card>();

            gatherSpoilsOfWar(warriors, playerList);
            playRound(warriors);
            distributeSpoilsOfWar(warVictor, players);
        }

        private void distributeSpoilsOfWar(List<Player> warVictor, List<Player> players)
        {
            if (warVictor.Count == 1)
                spoilsOfWar.ForEach(warVictor[0].AddCard);
            else
                throw new Exception("Multiple warVictors detected when only one expected");
        }

        private void gatherSpoilsOfWar(List<Player> warriors, List<Player> playerList)
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].CardCount > 0)
                    spoilsOfWar.Add(playerList[i].DrawCard());
            }

            for (int i = 0; i < warriors.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (warriors[i].CardCount > 1)
                    {
                        spoilsOfWar.Add(warriors[i].DrawCard());
                    }
                }
            }
        }

        private void playRound(List<Player> warriors)
        {
            warVictor = new List<Player>();

            for (int i = 0; i < warriors.Count; i++)
            {
                if (warVictor.Count == 0)
                    warVictor.Add(warriors[i]);

                else if (warriors[i].CheckCard().FaceValue > warVictor[0].CheckCard().FaceValue)
                {
                    warVictor.Clear();
                    warVictor.Add(players[i]);
                    Debug.WriteLine("players[{0}] is the current holder of highest value card overturned", i);
                    Debug.WriteLine("The list size is {0}", warVictor.Count);
                }

                else if (warriors[i].CheckCard().FaceValue == warVictor[0].CheckCard().FaceValue)
                {
                    warVictor.Add(warriors[i]);
                    Debug.WriteLine("players[{0}] is added to the list of those competing in War", i);
                    Debug.WriteLine("The list size is {0}", warVictor.Count);
                }
            }

            if (warVictor.Count > 1)
            {
                Console.WriteLine("Holy crap, there's a war inside this war‼");
                War war = new War(warVictor, players);
            }

            else
            {
                for (int i = 0; i < warriors.Count; i++)
                {
                    if (warriors[i].CardCount > 0)
                        spoilsOfWar.Add(warriors[i].DrawCard());
                }
            }

            foreach (Player warrior in warriors)
            {
                Console.WriteLine("Player\n Cards in hand: {0} \n Cards in discard deck: {1}", warrior.PlayHand.Count, warrior.DiscardPile.Count);
            }

            Console.WriteLine("\n");
        }
    }
}

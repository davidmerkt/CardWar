using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardWar;

namespace CardWarTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Card_CreateCard_Success()
        {
            //Arrange
            string expectedSuite = "Spades";
            string expectedFace = "Eight";
            int expectedFaceValue = 6;
            Card newCard = new Card(Suite.Spades, Face.Eight);

            //Act
            string actualSuite = newCard.Suite;
            string actualFace = newCard.Face;
            int actualFaceValue = newCard.FaceValue;

            //Assert
            Assert.AreEqual(expectedSuite, actualSuite);
            Assert.AreEqual(expectedFace, actualFace);
            Assert.AreEqual(expectedFaceValue, actualFaceValue);
        }

        [TestMethod]
        public void Card_Value_Success()
        {
            //Arrange
            Card card1 = new Card(Suite.Clubs, Face.Seven);
            Card card2 = new Card(Suite.Diamonds, Face.Queen);
            bool card1_lt_card2;

            //Act
            card1_lt_card2 = (card1.FaceValue < card2.FaceValue);

            //Assert
            Assert.IsTrue(card1_lt_card2);
        }

        [TestMethod]
        public void Card_Value_Success2()
        {
            //Arrange
            Card card1 = new Card(Suite.Clubs, Face.Jack);
            Card card2 = new Card(Suite.Diamonds, Face.Queen);
            bool card1_lt_card2;

            //Act
            card1_lt_card2 = (card1.FaceValue < card2.FaceValue);

            //Assert
            Assert.IsTrue(card1_lt_card2);
        }

        [TestMethod]
        public void Player_CreatePlayerDeck_Success()
        {
            //Arrange
            Player player = new Player();
            Card heartTwo = new Card(Suite.Hearts, Face.Two);
            Card heartThree = new Card(Suite.Hearts, Face.Three);
            Card heartFour = new Card(Suite.Hearts, Face.Four);

            //Act
            player.AddCard(heartTwo);
            player.AddCard(heartThree);
            player.AddCard(heartFour);

            //Assert
            Assert.AreEqual(3, player.DiscardPile.Count);
            Assert.AreEqual(0, player.PlayHand.Count);
        }

        [TestMethod]
        public void Player_DrawCard_Success()
        {
            //Arrange
            Player player = new Player();
            Card heartTwo = new Card(Suite.Hearts, Face.Two);
            Card heartThree = new Card(Suite.Hearts, Face.Three);
            Card heartFour = new Card(Suite.Hearts, Face.Four);

            //Act
            player.AddCard(heartTwo);
            player.AddCard(heartThree);
            player.AddCard(heartFour);

            //Assert
            Assert.AreEqual("Hearts", player.DrawCard().Suite);
            Assert.AreEqual(0, player.DiscardPile.Count);
            Assert.AreEqual(2, player.PlayHand.Count);
        }

        [TestMethod]
        public void Player_DrawCardEmptyDeck_ReturnsException()
        {
            //Arraange
            Player player = new Player();

            //Act
            try
            {
                player.DrawCard();
            }
            catch (Exception e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Player is out of cards");
            }
        }

        [TestMethod]
        public void Player_CardCount_ReturnsTotalCards()
        {
            //Arrange
            Player player = new Player();
            Card heartTwo = new Card(Suite.Hearts, Face.Two);
            Card heartThree = new Card(Suite.Hearts, Face.Three);
            Card heartFour = new Card(Suite.Hearts, Face.Four);
            player.AddCard(heartTwo);
            player.AddCard(heartThree);
            player.AddCard(heartFour);

            //Act
            player.AddCard(player.DrawCard());

            //Assert
            Assert.AreEqual(3, player.CardCount);
            Assert.AreEqual(2, player.PlayHand.Count);
            Assert.AreEqual(1, player.DiscardPile.Count);
        }

        //[TestMethod]
        //public void CreateDeck_Success()
        //{
        //    //Arrange
        //    List<Card> newDeck;
        //    CreateNewDeck(newDeck);

        //    //Act

        //    //Assert
        //}
    }
}

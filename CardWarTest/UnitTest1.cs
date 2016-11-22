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

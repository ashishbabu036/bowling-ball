using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            var game = new Game();
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_twenty_test()
        {
            var game = new Game();
            Roll(game, 1, 20);
            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_positiveValue_test()
        {
            var game = new Game();
            Roll_MockData(game, CreateMockData());
            Assert.AreEqual(187, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_maximum_score_test()
        {
            var game = new Game();
            Roll(game, 10, 21);
            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_all_spares_test()
        {
            var game = new Game();
            Roll(game, 5, 21);
            Assert.AreEqual(150, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_all_9s_test()
        {
            var game = new Game();
            Roll_MockData(game, CreateMockDataAll9s());
            Assert.AreEqual(90, game.GetScore());
        }

        public List<int> CreateMockData()
        {
            return new List<int>() { 10, 9,1, 5,5, 7,2, 10, 10, 10, 9,0, 8,2, 9,1,10 };
        }

        public List<int> CreateMockDataAll9s()
        {
            return new List<int>() { 9,0, 9,0, 9,0, 9,0, 9,0, 9,0, 9,0, 9,0, 9,0, 9,0 };
        }

        private void Roll_MockData(Game game, List<int> pins)
        {           
            for (int i = 0; i < pins.Count; i++)
            {
                game.Roll(pins[i]);
            }
        }

        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
    }
}

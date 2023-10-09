using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerTournamentSimulator.Simulations.Matches;

namespace SoccerTournamentSimulator.UnitTests.Matches
{
    [TestClass]
    public class AdvanceScoreManagerTests
    {
        [TestMethod]
        public void IncrementAdvanceScore_IncrementsByOne()
        {
            // Arrange
            AdvanceScoreManager manager = new AdvanceScoreManager();

            // Act
            int originalScore = manager.GetAdvanceScore();
            int newScore = manager.IncrementAdvanceScore();

            // Assert
            Assert.AreEqual(originalScore + 1, newScore);
        }

        [TestMethod]
        public void IncrementAdvanceScore_IncrementsByGivenAmount()
        {
            // Arrange
            AdvanceScoreManager manager = new AdvanceScoreManager();
            const int incrementAmount = 3;

            // Act
            int originalScore = manager.GetAdvanceScore();
            int newScore = manager.IncrementAdvanceScore(incrementAmount);

            // Assert
            Assert.AreEqual(originalScore + incrementAmount, newScore);
        }

        [TestMethod]
        public void IncrementAdvanceScore_DoesNotExceedMaximumScore()
        {
            // Arrange
            AdvanceScoreManager manager = new AdvanceScoreManager();
            int maximumScore = manager.GetMaximumAdvanceScore();

            // Act
            int newScore = manager.IncrementAdvanceScore(maximumScore + 1);

            // Assert
            Assert.AreEqual(maximumScore, newScore);
        }

        [TestMethod]
        public void SetAdvanceScoreToKickoff_SetsToKickoffScore()
        {
            // Arrange
            AdvanceScoreManager manager = new AdvanceScoreManager();

            // Act
            int newScore = manager.SetAdvanceScoreToKickoff();

            // Assert
            Assert.AreEqual(manager.GetKickoffAdvanceScore(), newScore);
        }

        [TestMethod]
        public void InvertAdvanceScore_ReturnsInvertedScore()
        {
            // Arrange
            AdvanceScoreManager manager = new AdvanceScoreManager();
            int originalScore = manager.GetAdvanceScore();

            // Act
            int invertedScore = manager.InvertAdvanceScore();

            // Assert
            Assert.AreEqual(manager.GetMaximumAdvanceScore() - originalScore, invertedScore);
        }

        [TestMethod]
        public void ResetAdvanceScore_ResetsToZero()
        {
            // Arrange
            AdvanceScoreManager manager = new AdvanceScoreManager();

            // Act
            int newScore = manager.ResetAdvanceScore();

            // Assert
            Assert.AreEqual(0, newScore);
        }
    }
}
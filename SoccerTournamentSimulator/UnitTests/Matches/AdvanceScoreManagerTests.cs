using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerTournamentSimulator.Simulations.Matches;
using SoccerTournamentSimulator.Simulations.Players.Actions;
using SoccerTournamentSimulator.Simulations.Teams;

namespace SoccerTournamentSimulator.UnitTests.Matches
{
    [TestClass]
    public class AdvanceScoreManagerTests
    {
        [TestMethod]
        public void UpdateAdvanceScore_IncreasesScoreByActionValue()
        {
            // Arrange
            AdvanceScoreManager manager = new AdvanceScoreManager();
            
            // Act
            manager.UpdateAdvanceScore(new LongPassPlayerAction());

            // Assert
            Assert.AreEqual(2, manager.GetAdvanceScore());
        }

        [TestMethod]
        public void SetAdvanceScoreToKickoff_SetsScoreToKickoffValue()
        {
            // Arrange
            AdvanceScoreManager manager = new AdvanceScoreManager();

            // Act
            manager.SetAdvanceScoreToKickoff();

            // Assert
            Assert.AreEqual(4, manager.GetAdvanceScore());
        }

        [TestMethod]
        public void ResetAdvanceScore_ResetsScoreToZero()
        {
            // Arrange
            AdvanceScoreManager manager = new AdvanceScoreManager();
            manager.UpdateAdvanceScore(new DribblePlayerAction());

            // Act
            manager.ResetAdvanceScore();

            // Assert
            Assert.AreEqual(0, manager.GetAdvanceScore());
        }

        [TestMethod]
        public void GetPlayerPositionAccordingToAdvanceScore_ReturnsCorrectPosition()
        {
            // Arrange: Should correspond to PlayerPosition.Forward.
            AdvanceScoreManager manager = new AdvanceScoreManager();
            manager.UpdateAdvanceScore(new LongPassPlayerAction());
            manager.UpdateAdvanceScore(new LongPassPlayerAction());
            manager.UpdateAdvanceScore(new LongPassPlayerAction());
            manager.UpdateAdvanceScore(new ShortPassPlayerAction());

            // Act
            PlayerPosition position = manager.GetPlayerPositionAccordingToAdvanceScore();

            // Assert
            Assert.AreEqual(PlayerPosition.Forward, position);
        }

        [TestMethod]
        public void GetPlayerPositionAccordingToInverseAdvanceScore_ReturnsCorrectPosition()
        {
            // Arrange: Should correspond to PlayerPosition.Defender.
            AdvanceScoreManager manager = new AdvanceScoreManager();
            manager.UpdateAdvanceScore(new LongPassPlayerAction());
            manager.UpdateAdvanceScore(new ShortPassPlayerAction());

            // Act
            PlayerPosition position = manager.GetPlayerPositionAccordingToInverseAdvanceScore();

            // Assert
            Assert.AreEqual(PlayerPosition.Midfielder, position);
        }

        [TestMethod]
        public void GetAdvanceMultiplier_ReturnsCorrectMultiplier()
        {
            // Arrange
            AdvanceScoreManager manager = new AdvanceScoreManager();
            manager.UpdateAdvanceScore(new LongPassPlayerAction());
            manager.UpdateAdvanceScore(new LongPassPlayerAction());
            manager.UpdateAdvanceScore(new ShortPassPlayerAction());

            // Act
            float multiplier = manager.GetAdvanceMultiplier();

            // Assert: Allow a small tolerance for floating-point comparison.
            Assert.AreEqual(0.5555556f, multiplier, 0.000001f);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerTournamentSimulator.Simulations.Players;
using SoccerTournamentSimulator.Simulations.Players.Actions;

namespace SoccerTournamentSimulator.UnitTests.Players
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void GetPlayerActionSuccess_ReturnsValidSuccessValue()
        {
            // Arrange
            const int playerId = 1;
            const string playerName = "TestPlayer";
            const float goalSuccess = 0.8f;
            const float shortPassSuccess = 0.7f;
            const float longPassSuccess = 0.6f;
            const float dribbleSuccess = 0.75f;
            const float interceptionSuccess = 0.65f;
            const float tackleSuccess = 0.7f;
            const float saveSuccess = 0.9f;

            Player player = new TestPlayer(
                playerId,
                playerName,
                goalSuccess,
                shortPassSuccess,
                longPassSuccess,
                dribbleSuccess,
                interceptionSuccess,
                tackleSuccess,
                saveSuccess);

            const float advanceMultiplier = 1.0f;

            // Act
            float playerActionSuccess = player.GetPlayerActionSuccess(
                advanceMultiplier, out IPlayerAction playerAction);

            // Assert
            Assert.IsNotNull(playerAction);
            Assert.IsTrue(playerActionSuccess >= 0f && playerActionSuccess <= 1f);
        }

        // Create a TestPlayer class that inherits from Player for testing purposes.
        private class TestPlayer : Player
        {
            public TestPlayer(
                int id,
                string name,
                float goalSuccess,
                float shortPassSuccess,
                float longPassSuccess,
                float dribbleSuccess,
                float interceptionSuccess,
                float tackleSuccess,
                float saveSuccess)
                : base(
                    id,
                    name,
                    goalSuccess,
                    shortPassSuccess,
                    longPassSuccess,
                    dribbleSuccess,
                    interceptionSuccess,
                    tackleSuccess,
                    saveSuccess)
            {
            }
        }
    }
}
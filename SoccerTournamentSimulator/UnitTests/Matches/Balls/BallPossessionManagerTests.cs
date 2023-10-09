using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerTournamentSimulator.Simulations.Matches.Balls;
using SoccerTournamentSimulator.Simulations.Players;
using SoccerTournamentSimulator.Simulations.Teams;

namespace SoccerTournamentSimulator.UnitTests.Matches.Balls
{
    [TestClass]
    public class BallPossessionManagerTests
    {
        [TestMethod]
        public void SetInitialBallPossessionToTeam_ShouldSetInitialBallPossessionTeam()
        {
            // Arrange
            BallPossessionManager manager = new BallPossessionManager();
            Team team = new Team(1, "TeamA", null, null, null, null);

            // Act
            manager.SetInitialBallPossessionToTeam(team);

            // Assert
            Assert.AreEqual(team, manager.InitialBallPossessionTeam);
        }

        [TestMethod]
        public void SetBallPossessionToTeam_ShouldSetBallPossessionTeam()
        {
            // Arrange
            BallPossessionManager manager = new BallPossessionManager();
            Team team = new Team(1, "TeamA", null, null, null, null);

            // Act
            manager.SetBallPossessionToTeam(team);

            // Assert
            Assert.AreEqual(team, manager.BallPossessionTeam);
        }

        [TestMethod]
        public void SetBallPossessionToPlayer_ShouldSetBallPossessionPlayer()
        {
            // Arrange
            BallPossessionManager manager = new BallPossessionManager();
            Defender player = new Defender(1, "PlayerA", 0.8f, 0.7f, 0.6f, 0.9f, 0.8f, 0.7f, 0.9f);

            // Act
            manager.SetBallPossessionToPlayer(player);

            // Assert
            Assert.AreEqual(player, manager.BallPossessionPlayer);
        }

        [TestMethod]
        public void SetBallPossessionToRandomPlayerByPosition_ShouldSetBallPossessionPlayer()
        {
            // Arrange
            BallPossessionManager manager = new BallPossessionManager();
            List<Forward> forwards = new List<Forward>
            {
                new Forward(1, "Forward1", 0.9f, 0.8f, 0.7f, 0.9f, 0.8f, 0.7f, 0.9f),
                new Forward(2, "Forward2", 0.8f, 0.7f, 0.6f, 0.9f, 0.8f, 0.7f, 0.9f)
            };
            Team team = new Team(1, "TeamA", null, null, null, forwards);
            manager.SetInitialBallPossessionToTeam(team);

            // Act
            manager.SetBallPossessionToRandomPlayerByPosition(PlayerPosition.Forward);

            // Assert
            Assert.IsNotNull(manager.BallPossessionPlayer);
            Assert.IsTrue(team.Forwards.Contains(manager.BallPossessionPlayer));
        }
    }
}
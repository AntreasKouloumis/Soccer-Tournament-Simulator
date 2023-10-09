using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerTournamentSimulator.Simulations.Players;
using SoccerTournamentSimulator.Simulations.Teams;

namespace SoccerTournamentSimulator.UnitTests.Teams
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void GetPlayerById_ShouldReturnPlayer_WhenPlayerExists()
        {
            // Arrange
            GoalKeeper goalKeeper = new GoalKeeper(1, "Player1", 0.9f, 0.8f, 0.7f, 0.85f, 0.2f, 0.3f, 0.1f);
            List<Defender> defenders = new List<Defender>
                { new Defender(2, "Player2", 0.8f, 0.7f, 0.6f, 0.75f, 0.3f, 0.4f, 0.2f) };
            List<Midfielder> midfielders = new List<Midfielder>
                { new Midfielder(3, "Player3", 0.85f, 0.75f, 0.7f, 0.8f, 0.4f, 0.5f, 0.2f) };
            List<Forward> forwards = new List<Forward> { new Forward(4, "Player4", 0.9f, 0.85f, 0.8f, 0.9f, 0.3f, 0.4f, 0.1f) };

            Team team = new Team(1, "Team1", goalKeeper, defenders, midfielders, forwards);

            // Act: Get the Defender with ID 2.
            const int id = 2;
            Player player = team.GetPlayerById(id);

            // Assert
            Assert.IsNotNull(player);
            Assert.IsInstanceOfType(player, typeof(Defender));
            Assert.AreEqual(id, player.IdData.Id);
        }

        [TestMethod]
        public void GetPlayerById_ShouldReturnNull_WhenPlayerDoesNotExist()
        {
            // Arrange
            GoalKeeper goalKeeper = new GoalKeeper(1, "Player1", 0.9f, 0.8f, 0.7f, 0.85f, 0.2f, 0.3f, 0.1f);
            List<Defender> defenders = new List<Defender>
                { new Defender(2, "Player2", 0.8f, 0.7f, 0.6f, 0.75f, 0.3f, 0.4f, 0.2f) };
            List<Midfielder> midfielders = new List<Midfielder>
                { new Midfielder(3, "Player3", 0.85f, 0.75f, 0.7f, 0.8f, 0.4f, 0.5f, 0.2f) };
            List<Forward> forwards = new List<Forward> { new Forward(4, "Player4", 0.9f, 0.85f, 0.8f, 0.9f, 0.3f, 0.4f, 0.1f) };
            
            Team team = new Team(1, "Team1", goalKeeper, defenders, midfielders, forwards);

            // Act: Player with ID 5 does not exist.
            Player player = team.GetPlayerById(5); 

            // Assert
            Assert.IsNull(player);
        }

        [TestMethod]
        public void GetRandomPlayerByPlayerPosition_ShouldReturnPlayer_WhenPlayerExists()
        {
            // Arrange
            GoalKeeper goalKeeper = new GoalKeeper(1, "Player1", 0.9f, 0.8f, 0.7f, 0.85f, 0.2f, 0.3f, 0.1f);
            List<Defender> defenders = new List<Defender>
                { new Defender(2, "Player2", 0.8f, 0.7f, 0.6f, 0.75f, 0.3f, 0.4f, 0.2f) };
            List<Midfielder> midfielders = new List<Midfielder>
                { new Midfielder(3, "Player3", 0.85f, 0.75f, 0.7f, 0.8f, 0.4f, 0.5f, 0.2f) };
            List<Forward> forwards = new List<Forward> { new Forward(4, "Player4", 0.9f, 0.85f, 0.8f, 0.9f, 0.3f, 0.4f, 0.1f) };
            
            Team team = new Team(1, "Team1", goalKeeper, defenders, midfielders, forwards);

            // Act
            Player player = team.GetRandomPlayerByPlayerPosition(PlayerPosition.Defender);

            // Assert
            Assert.IsNotNull(player);
            Assert.IsInstanceOfType(player, typeof(Defender));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetRandomPlayerByPlayerPosition_ShouldThrowException_WhenUnsupportedPlayerPosition()
        {
            // Arrange
            GoalKeeper goalKeeper = new GoalKeeper(1, "Player1", 0.9f, 0.8f, 0.7f, 0.85f, 0.2f, 0.3f, 0.1f);
            List<Defender> defenders = new List<Defender>
                { new Defender(2, "Player2", 0.8f, 0.7f, 0.6f, 0.75f, 0.3f, 0.4f, 0.2f) };
            List<Midfielder> midfielders = new List<Midfielder>
                { new Midfielder(3, "Player3", 0.85f, 0.75f, 0.7f, 0.8f, 0.4f, 0.5f, 0.2f) };
            List<Forward> forwards = new List<Forward> { new Forward(4, "Player4", 0.9f, 0.85f, 0.8f, 0.9f, 0.3f, 0.4f, 0.1f) };

            Team team = new Team(1, "Team1", goalKeeper, defenders, midfielders, forwards);

            // Act: Use an unsupported value, e.g., 100.
            Player player = team.GetRandomPlayerByPlayerPosition((PlayerPosition)100);

            // Assert (Exception is expected)
        }
    }
}
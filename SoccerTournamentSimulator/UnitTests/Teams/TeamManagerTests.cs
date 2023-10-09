using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerTournamentSimulator.Simulations.Teams;

namespace SoccerTournamentSimulator.UnitTests.Teams
{
    [TestClass]
    public class TeamManagerTests
    {
        private Tuple<Team, Team> teamsTuple;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange: Create a teamIdData tuple for testing.
            teamsTuple = new Tuple<Team, Team>(
                new Team(1, "Team1", null, null, null, null),
                new Team(2, "Team2", null, null, null, null));
        }

        [TestMethod]
        public void GetTeamById_ValidId_ReturnsTeam()
        {
            // Arrange
            TeamManager teamManager = new TeamManager(teamsTuple);

            // Act
            Team result = teamManager.GetTeamById(1);

            // Assert
            Assert.AreEqual(teamsTuple.Item1, result);
        }

        [TestMethod]
        public void GetTeamById_InvalidId_ReturnsNull()
        {
            // Arrange
            TeamManager teamManager = new TeamManager(teamsTuple);

            // Act
            Team result = teamManager.GetTeamById(3);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetOpposingTeamById_ValidId_ReturnsOpposingTeam()
        {
            // Arrange
            TeamManager teamManager = new TeamManager(teamsTuple);

            // Act
            Team result = teamManager.GetOpposingTeamById(1);

            // Assert
            Assert.AreEqual(teamsTuple.Item2, result);
        }

        [TestMethod]
        public void GetOpposingTeamById_InvalidId_ReturnsNull()
        {
            // Arrange
            var teamManager = new TeamManager(teamsTuple);

            // Act
            var result = teamManager.GetOpposingTeamById(3);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetTeam_HomeStatus_ReturnsHomeTeam()
        {
            // Arrange
            var teamManager = new TeamManager(teamsTuple);

            // Act
            var result = teamManager.GetTeam(TeamStatus.Home);

            // Assert
            Assert.AreEqual(teamsTuple.Item1, result);
        }

        [TestMethod]
        public void GetTeam_AwayStatus_ReturnsAwayTeam()
        {
            // Arrange
            var teamManager = new TeamManager(teamsTuple);

            // Act
            var result = teamManager.GetTeam(TeamStatus.Away);

            // Assert
            Assert.AreEqual(teamsTuple.Item2, result);
        }
    }
}
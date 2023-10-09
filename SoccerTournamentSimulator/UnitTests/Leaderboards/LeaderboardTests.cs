using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerTournamentSimulator.Simulations.Leaderboards;
using SoccerTournamentSimulator.Simulations.Players;

namespace SoccerTournamentSimulator.UnitTests.Leaderboards
{
    [TestClass]
    public class LeaderboardTests
    {
        [TestMethod]
        public void SetLeaderboard_ShouldSetTeamStats()
        {
            // Arrange
            List<TeamStats> initialTeamStats = new List<TeamStats>
            {
                new TeamStats(new IdData(1, "Team1")),
                new TeamStats(new IdData(2, "Team2")),
            };
            Leaderboard leaderboard = new Leaderboard(initialTeamStats);

            List<TeamStats> newTeamStats = new List<TeamStats>
            {
                new TeamStats(new IdData(3, "Team3")),
                new TeamStats(new IdData(4, "Team4")),
            };

            // Act
            leaderboard.SetLeaderboard(newTeamStats);

            // Assert
            CollectionAssert.AreEqual(newTeamStats, leaderboard.TeamStats);
        }

        [TestMethod]
        public void SetTeamStats_ShouldUpdateTeamStatsEntry()
        {
            // Arrange
            List<TeamStats> initialTeamStats = new List<TeamStats>
            {
                new TeamStats(new IdData(1, "Team1")),
                new TeamStats(new IdData(2, "Team2")),
            };
            Leaderboard leaderboard = new Leaderboard(initialTeamStats);

            TeamStats newTeamStats = new TeamStats(new IdData(1, "Team1"))
            {
                wins = 5,
                points = 15,
            };

            // Act
            leaderboard.SetTeamStats(newTeamStats);

            // Assert
            TeamStats updatedTeamStats = leaderboard.GetTeamStatsById(1);
            Assert.AreEqual(5, updatedTeamStats.wins);
            Assert.AreEqual(15, updatedTeamStats.points);
        }

        [TestMethod]
        public void GetTeamStatsById_ShouldReturnTeamStatsForValidId()
        {
            // Arrange
            List<TeamStats> initialTeamStats = new List<TeamStats>
            {
                new TeamStats(new IdData(1, "Team1")),
                new TeamStats(new IdData(2, "Team2")),
            };
            Leaderboard leaderboard = new Leaderboard(initialTeamStats);

            // Act
            TeamStats teamStats = leaderboard.GetTeamStatsById(1);

            // Assert
            Assert.IsNotNull(teamStats);
            Assert.AreEqual(1, teamStats.IdData.Id);
        }

        [TestMethod]
        public void GetTeamStatsById_ShouldReturnNullForInvalidId()
        {
            // Arrange
            List<TeamStats> initialTeamStats = new List<TeamStats>
            {
                new TeamStats(new IdData(1, "Team1")),
                new TeamStats(new IdData(2, "Team2")),
            };
            Leaderboard leaderboard = new Leaderboard(initialTeamStats);

            // Act
            TeamStats teamStats = leaderboard.GetTeamStatsById(3);

            // Assert
            Assert.IsNull(teamStats);
        }

        [TestMethod]
        public void SortByPoints_ShouldSortTeamStatsByPointsDescending()
        {
            // Arrange
            List<TeamStats> teamStats = new List<TeamStats>
            {
                new TeamStats(new IdData(1, "Team1")) { points = 15 },
                new TeamStats(new IdData(2, "Team2")) { points = 10 },
                new TeamStats(new IdData(3, "Team3")) { points = 20 },
            };
            Leaderboard leaderboard = new Leaderboard(teamStats);

            // Act
            leaderboard.SortByPoints();

            // Assert
            List<TeamStats> sortedTeamStats = leaderboard.TeamStats;
            Assert.AreEqual(3, sortedTeamStats[0].IdData.Id);
            Assert.AreEqual(1, sortedTeamStats[1].IdData.Id);
            Assert.AreEqual(2, sortedTeamStats[2].IdData.Id);
        }
    }
}
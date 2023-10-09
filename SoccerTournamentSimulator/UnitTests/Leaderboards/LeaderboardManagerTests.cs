using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerTournamentSimulator.Simulations.Leaderboards;
using SoccerTournamentSimulator.Simulations.Matches.Scores;
using SoccerTournamentSimulator.Simulations.Players;

namespace SoccerTournamentSimulator.UnitTests.Leaderboards
{
    [TestClass]
    public class LeaderboardManagerTests
    {
        private List<IdData> teamIdData = new List<IdData>();
        private MatchScore matchScore1;
        private MatchScore matchScore2;
        private MatchScore matchScore3;
        private MatchScore matchScore4;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange: Create a teamIdData list for testing.
            teamIdData = new List<IdData>
            {
                new IdData(1, "Team1"),
                new IdData(2, "Team2"),
                new IdData(3, "Team3")
            };
            
            // Arrange: Create MatchScore instances for testing.
            matchScore1 = new MatchScore(new Tuple<IdData, IdData>(teamIdData[0], teamIdData[1]));
            matchScore1.IncrementHomeTeamScore();
            matchScore1.IncrementHomeTeamScore();
            matchScore1.IncrementAwayTeamScore();
            matchScore2 = new MatchScore(new Tuple<IdData, IdData>(teamIdData[2], teamIdData[1]));
            matchScore2.IncrementAwayTeamScore();
            matchScore2.IncrementAwayTeamScore();
            matchScore3 = new MatchScore(new Tuple<IdData, IdData>(teamIdData[0], teamIdData[2]));
            matchScore3.IncrementHomeTeamScore();
            matchScore3.IncrementAwayTeamScore();
            matchScore4 = new MatchScore(new Tuple<IdData, IdData>(teamIdData[1], teamIdData[0]));
            matchScore4.IncrementHomeTeamScore();
            matchScore4.IncrementHomeTeamScore();
            matchScore4.IncrementAwayTeamScore();
            matchScore4.IncrementAwayTeamScore();
        }
        
        [TestMethod]
        public void InitializeLeaderboard_WithTeamIdData_ShouldCreateLeaderboardWithTeamStats()
        {
            // Arrange

            // Act
            LeaderboardManager leaderboardManager = new LeaderboardManager(teamIdData);

            // Assert
            Assert.IsNotNull(leaderboardManager.Leaderboard);
            Assert.AreEqual(teamIdData.Count, leaderboardManager.Leaderboard.TeamStats.Count);
        }

        [TestMethod]
        public void UpdateLeaderboard_WithTournamentScore_ShouldUpdateLeaderboard()
        {
            // Arrange
            LeaderboardManager leaderboardManager = new LeaderboardManager(teamIdData);

            List<List<MatchScore>> matchScores = new List<List<MatchScore>>
            {
                new List<MatchScore>
                {
                    matchScore1,
                    matchScore2
                },
                new List<MatchScore>
                {
                    matchScore3,
                    matchScore4
                }
            };
            
            TournamentScore tournamentScore = new TournamentScore(matchScores);

            // Act
            Leaderboard updatedLeaderboard = leaderboardManager.UpdateLeaderboard(tournamentScore);

            // Assert
            Assert.IsNotNull(updatedLeaderboard);
            Assert.AreEqual(3, updatedLeaderboard.TeamStats.Count);
            
            // Check if the leaderboard is sorted by points (descending order).
            Assert.AreEqual("Team1", updatedLeaderboard.TeamStats[0].IdData.Name);
            Assert.AreEqual("Team2", updatedLeaderboard.TeamStats[1].IdData.Name);
            Assert.AreEqual("Team3", updatedLeaderboard.TeamStats[2].IdData.Name);

            // Check individual team stats.
            Assert.AreEqual(3, updatedLeaderboard.TeamStats[0].gamesPlayed);
            Assert.AreEqual(3, updatedLeaderboard.TeamStats[1].gamesPlayed);
            Assert.AreEqual(2, updatedLeaderboard.TeamStats[2].gamesPlayed);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerTournamentSimulator.Simulations.Matches.Scores;
using SoccerTournamentSimulator.Simulations.Players;

namespace SoccerTournamentSimulator.UnitTests.Matches.Scores
{
    [TestClass]
    public class MatchScoreTests
    {
        private Tuple<IdData, IdData> testPairing;
        private MatchScore matchScore;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange: Create a test pairing.
            IdData team1 = new IdData(1, "Team A");
            IdData team2 = new IdData(2, "Team B");
            testPairing = new Tuple<IdData, IdData>(team1, team2);

            // Arrange: Create a MatchScore instance for testing.
            matchScore = new MatchScore(testPairing);
        }

        [TestMethod]
        public void IncrementHomeTeamScore_ShouldIncrementHomeTeamScore()
        {
            // Act
            int initialScore = matchScore.HomeTeamScore;
            matchScore.IncrementHomeTeamScore();
            int updatedScore = matchScore.HomeTeamScore;

            // Assert
            Assert.AreEqual(initialScore + 1, updatedScore);
        }

        [TestMethod]
        public void IncrementAwayTeamScore_ShouldIncrementAwayTeamScore()
        {
            // Act
            int initialScore = matchScore.AwayTeamScore;
            matchScore.IncrementAwayTeamScore();
            int updatedScore = matchScore.AwayTeamScore;

            // Assert
            Assert.AreEqual(initialScore + 1, updatedScore);
        }

        [TestMethod]
        public void IncrementTeamScoreById_ShouldIncrementHomeTeamScore_WhenMatchingTeam1Id()
        {
            // Arrange
            int team1Id = testPairing.Item1.Id;

            // Act
            int initialHomeScore = matchScore.HomeTeamScore;
            int result = matchScore.IncrementTeamScoreById(team1Id);
            int updatedHomeScore = matchScore.HomeTeamScore;

            // Assert
            Assert.AreEqual(1, result);
            Assert.AreEqual(initialHomeScore + 1, updatedHomeScore);
        }

        [TestMethod]
        public void IncrementTeamScoreById_ShouldIncrementAwayTeamScore_WhenMatchingTeam2Id()
        {
            // Arrange
            int team2Id = testPairing.Item2.Id;

            // Act
            int initialAwayScore = matchScore.AwayTeamScore;
            int result = matchScore.IncrementTeamScoreById(team2Id);
            int updatedAwayScore = matchScore.AwayTeamScore;

            // Assert
            Assert.AreEqual(1, result);
            Assert.AreEqual(initialAwayScore + 1, updatedAwayScore);
        }

        [TestMethod]
        public void IncrementTeamScoreById_ShouldReturnNegative_WhenIdDoesNotMatchEitherTeam()
        {
            // Act
            int result = matchScore.IncrementTeamScoreById(3);

            // Assert
            Assert.AreEqual(-1, result);
        }
    }
}
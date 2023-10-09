using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerTournamentSimulator.Simulations.Matches.Scores;
using SoccerTournamentSimulator.Simulations.Players;

namespace SoccerTournamentSimulator.UnitTests.Matches.Scores
{
    [TestClass]
    public class TournamentScoreTests
    {
    
        private List<List<Tuple<IdData, IdData>>> testPairings;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange: Create some sample pairings for testing.
            testPairings = new List<List<Tuple<IdData, IdData>>>
            {
                new List<Tuple<IdData, IdData>>
                {
                    new Tuple<IdData, IdData>(new IdData(1, "TeamA"), new IdData(2, "TeamB")),
                    new Tuple<IdData, IdData>(new IdData(3, "TeamC"), new IdData(4, "TeamD"))
                },
                new List<Tuple<IdData, IdData>>
                {
                    new Tuple<IdData, IdData>(new IdData(5, "TeamE"), new IdData(6, "TeamF")),
                    new Tuple<IdData, IdData>(new IdData(7, "TeamG"), new IdData(8, "TeamH"))
                }
            };
        }

        [TestMethod]
        public void Constructor_WithValidPairings_InitializesMatchScores()
        {
            // Arrange

            // Act
            TournamentScore tournamentScore = new TournamentScore(testPairings);

            // Assert
            Assert.IsNotNull(tournamentScore);
            Assert.AreEqual(testPairings.Count, tournamentScore.GetTournamentMatchScores().Count);
            Assert.AreEqual(testPairings[0].Count, tournamentScore.GetTournamentMatchScores()[0].Count);
        }

        [TestMethod]
        public void AddMatchScore_WithValidMatchScore_AddsMatchScoreToTournament()
        {
            // Arrange
            TournamentScore tournamentScore = new TournamentScore(testPairings);
            MatchScore matchScore = new MatchScore(testPairings[0][0]);

            // Act
            tournamentScore.AddMatchScore(matchScore);

            // Assert
            List<List<MatchScore>> tournamentMatchScores = tournamentScore.GetTournamentMatchScores();
            Assert.IsNotNull(tournamentMatchScores);
            Assert.AreEqual(testPairings.Count, tournamentMatchScores.Count);
            Assert.AreEqual(testPairings[0].Count, tournamentMatchScores[0].Count);
            Assert.AreEqual(matchScore, tournamentMatchScores[0][0]);
        }

        [TestMethod]
        public void GetRoundMatchScores_WithValidRoundIndex_ReturnsRoundMatchScores()
        {
            // Arrange
            TournamentScore tournamentScore = new TournamentScore(testPairings);

            // Act
            const int roundIndex = 1;
            List<MatchScore> roundMatchScores = tournamentScore.GetRoundMatchScores(roundIndex);

            // Assert
            Assert.IsNotNull(roundMatchScores);
            Assert.AreEqual(testPairings[roundIndex].Count, roundMatchScores.Count);
        }

        [TestMethod]
        public void GetMatchScore_WithValidIndices_ReturnsMatchScore()
        {
            // Arrange
            TournamentScore tournamentScore = new TournamentScore(testPairings);

            // Act
            const int roundIndex = 0;
            const int matchIndex = 1;
            MatchScore matchScore = tournamentScore.GetMatchScore(roundIndex, matchIndex);

            // Assert
            Assert.IsNotNull(matchScore);
            Assert.AreEqual(testPairings[roundIndex][matchIndex], matchScore.Pairing);
        }
    }
}
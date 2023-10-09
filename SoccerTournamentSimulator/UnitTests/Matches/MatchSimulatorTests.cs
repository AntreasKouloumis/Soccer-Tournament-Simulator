using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerTournamentSimulator.Simulations.CoinToss;
using SoccerTournamentSimulator.Simulations.Matches;
using SoccerTournamentSimulator.Simulations.Matches.Balls;
using SoccerTournamentSimulator.Simulations.Matches.Interactions;
using SoccerTournamentSimulator.Simulations.Matches.Scores;
using SoccerTournamentSimulator.Simulations.Players;
using SoccerTournamentSimulator.Simulations.Teams;
using SoccerTournamentSimulator.UnitTests.Matches.Interactions;

namespace SoccerTournamentSimulator.UnitTests.Matches
{
    [TestClass]
    public class MatchSimulatorTests
    {
        private Tuple<IdData, IdData> teamIdDataPairing;
        private Tuple<Team, Team> teamPairing;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            GoalKeeper goalKeeper = new GoalKeeper(1, "Player1", 0.9f, 0.8f, 0.7f, 0.85f, 0.2f, 0.3f, 0.1f);
            List<Defender> defenders = new List<Defender>
                { new Defender(2, "Player2", 0.8f, 0.7f, 0.6f, 0.75f, 0.3f, 0.4f, 0.2f) };
            List<Midfielder> midfielders = new List<Midfielder>
                { new Midfielder(3, "Player3", 0.85f, 0.75f, 0.7f, 0.8f, 0.4f, 0.5f, 0.2f) };
            List<Forward> forwards = new List<Forward>
                { new Forward(4, "Player4", 0.9f, 0.85f, 0.8f, 0.9f, 0.3f, 0.4f, 0.1f) };
            
            // Arrange: Create a test pairing.
            IdData teamIdData1 = new IdData(1, "Team A");
            IdData teamIdData2 = new IdData(2, "Team B");
            teamIdDataPairing = new Tuple<IdData, IdData>(teamIdData1, teamIdData2);
            
            // Arrange: Create a team tuple for testing.
            Team team1 = new Team(1, "Team1", goalKeeper, defenders, midfielders, forwards);
            Team team2 = new Team(2, "Team2", goalKeeper, defenders, midfielders, forwards);
            teamPairing = new Tuple<Team, Team>(team1, team2);
        }

        [TestMethod]
        public void SimulateMatch_MovesToLastState()
        {
            // Arrange
            ControlledRandom controlledRandom = new ControlledRandom(0.6);
            MatchScoreManager matchScoreManager = new MatchScoreManager(teamIdDataPairing);
            BallPossessionManager ballPossessionManager = new BallPossessionManager();
            InteractionSimulator interactionSimulator = new InteractionSimulator(controlledRandom);
            CoinTossManager coinTossManager = new CoinTossManager();
            TeamManager teamManager = new TeamManager(teamPairing);
            MatchStateManager matchStateManager = new MatchStateManager();
            AdvanceScoreManager advanceScoreManager = new AdvanceScoreManager();

            MatchSimulator matchSimulator = new MatchSimulator(
                matchScoreManager,
                ballPossessionManager,
                interactionSimulator,
                coinTossManager,
                teamManager,
                matchStateManager,
                advanceScoreManager,
                controlledRandom);

            // Act
            matchSimulator.SimulateMatch();

            // Assert
            Assert.AreEqual(MatchState.FinalWhistle, matchStateManager.MatchState);
        }

        [TestMethod]
        public void SimulateMatch_SetsInitialBallPossession()
        {
            // Arrange
            ControlledRandom controlledRandom = new ControlledRandom(0.6);
            MatchScoreManager matchScoreManager = new MatchScoreManager(teamIdDataPairing);
            BallPossessionManager ballPossessionManager = new BallPossessionManager();
            InteractionSimulator interactionSimulator = new InteractionSimulator(controlledRandom);
            CoinTossManager coinTossManager = new CoinTossManager();
            TeamManager teamManager = new TeamManager(teamPairing);
            MatchStateManager matchStateManager = new MatchStateManager();
            AdvanceScoreManager advanceScoreManager = new AdvanceScoreManager();

            MatchSimulator matchSimulator = new MatchSimulator(
                matchScoreManager,
                ballPossessionManager,
                interactionSimulator,
                coinTossManager,
                teamManager,
                matchStateManager,
                advanceScoreManager,
                controlledRandom);

            // Act
            matchSimulator.SimulateMatch();

            // Assert
            Assert.IsNotNull(ballPossessionManager.InitialBallPossessionTeam);
        }

        [TestMethod]
        public void SimulateMatch_SetsBallPossessionForSecondHalf()
        {
            // Arrange
            ControlledRandom controlledRandom = new ControlledRandom(0.6);
            MatchScoreManager matchScoreManager = new MatchScoreManager(teamIdDataPairing);
            BallPossessionManager ballPossessionManager = new BallPossessionManager();
            InteractionSimulator interactionSimulator = new InteractionSimulator(controlledRandom);
            CoinTossManager coinTossManager = new CoinTossManager();
            TeamManager teamManager = new TeamManager(teamPairing);
            MatchStateManager matchStateManager = new MatchStateManager();
            AdvanceScoreManager advanceScoreManager = new AdvanceScoreManager();

            MatchSimulator matchSimulator = new MatchSimulator(
                matchScoreManager,
                ballPossessionManager,
                interactionSimulator,
                coinTossManager,
                teamManager,
                matchStateManager,
                advanceScoreManager,
                controlledRandom);

            // Act
            matchSimulator.SimulateMatch();

            // Assert
            Assert.IsNotNull(ballPossessionManager.BallPossessionTeam);
            Assert.AreEqual(ballPossessionManager.BallPossessionTeam,
                teamManager.GetOpposingTeamById(ballPossessionManager.InitialBallPossessionTeam.IdData.Id));
        }
    }
}
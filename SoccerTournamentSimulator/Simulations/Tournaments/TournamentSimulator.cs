using SoccerTournamentSimulator.Simulations.CoinToss;
using SoccerTournamentSimulator.Simulations.Leaderboards;
using SoccerTournamentSimulator.Simulations.Matches;
using SoccerTournamentSimulator.Simulations.Matches.Balls;
using SoccerTournamentSimulator.Simulations.Matches.Interactions;
using SoccerTournamentSimulator.Simulations.Matches.Scores;
using SoccerTournamentSimulator.Simulations.Pairings;
using SoccerTournamentSimulator.Simulations.Players;
using SoccerTournamentSimulator.Simulations.Teams;

namespace SoccerTournamentSimulator.Simulations.Tournaments
{
    /// <summary>
    /// Simulates a tournament with matches between a number of teams.
    /// </summary>
    public class TournamentSimulator
    {
        private ITeamDatabase teamDatabase;
        private IPairingsGenerator pairingsGenerator;
        private TournamentScoreManager tournamentScoreManager;
        private LeaderboardManager leaderboardManager;
        private ITournamentBracketPrinter iTournamentBracketPrinter;
        private ILeaderboardPrinter iLeaderboardPrinter;
        private MatchSimulator? matchSimulator;

        private List<List<Tuple<IdData, IdData>>> pairingsIdData =
            new List<List<Tuple<IdData, IdData>>>();

        private int currentRoundIndex;
        private int currentMatchIndex;

        public event EventHandler<TournamentScoreEventArgs>? OnTournamentEnded;
        public event EventHandler<LeaderboardEventArgs>? OnLeaderboardUpdated;

        private readonly Random random = new Random();

        public TournamentSimulator(ITeamDatabase teamDatabase,
            IPairingsGenerator pairingsGenerator,
            TournamentScoreManager tournamentScoreManager,
            LeaderboardManager leaderboardManager,
            ITournamentBracketPrinter iTournamentBracketPrinter,
            ILeaderboardPrinter iLeaderboardPrinter)
        {
            this.teamDatabase = teamDatabase;
            this.pairingsGenerator = pairingsGenerator;
            this.tournamentScoreManager = tournamentScoreManager;
            this.leaderboardManager = leaderboardManager;
            this.iTournamentBracketPrinter = iTournamentBracketPrinter;
            this.iLeaderboardPrinter = iLeaderboardPrinter;
        }

        /// <summary>
        /// Simulates a tournament.
        /// </summary>
        public void SimulateTournament()
        {
            List<int> teamIds = teamDatabase.GetTeamIds();
            pairingsIdData = ConvertToIdData(pairingsGenerator.GeneratePairings(teamIds));
            tournamentScoreManager.InitializeTournamentScore(pairingsIdData);
            
            leaderboardManager.InitializeLeaderboard(teamDatabase.GetTeamIdData());

            SimulateTournamentBracket(pairingsIdData[currentRoundIndex][currentMatchIndex]);
        }

        private List<List<Tuple<IdData, IdData>>> ConvertToIdData(IReadOnlyList<List<Tuple<int, int>>> pairings)
        {
            List<List<Tuple<IdData, IdData>>> idData = new List<List<Tuple<IdData, IdData>>>();
            for (int i = 0; i < pairings.Count; i++)
            {
                List<Tuple<IdData, IdData>> roundIdData = new List<Tuple<IdData, IdData>>();
                for (int j = 0; j < pairings[i].Count; j++)
                    roundIdData.Add(teamDatabase.GetIdDataPairingByIds(pairings[i][j]));

                idData.Add(roundIdData);
            }

            return idData;
        }

        private void DetermineNextTournamentBracket()
        {
            currentMatchIndex++;
            if (currentMatchIndex >= pairingsIdData[currentRoundIndex].Count)
            {
                currentMatchIndex = 0;
                currentRoundIndex++;
            }

            if (currentRoundIndex < pairingsIdData.Count)
                SimulateTournamentBracket(pairingsIdData[currentRoundIndex][currentMatchIndex]);
            else
                TournamentEnded();
        }

        /// <summary>
        /// Simulates a bracket of the tournament.
        /// </summary>
        /// <param name="pairing">Pairing of team ids that are matched against each other.</param>
        private void SimulateTournamentBracket(Tuple<IdData, IdData> pairing)
        {
            matchSimulator = new MatchSimulator(
                new MatchScoreManager(pairing),
                new BallPossessionManager(),
                new InteractionSimulator(random),
                new CoinTossManager(),
                new TeamManager(teamDatabase.GetTeamPairingByIdData(pairing)),
                new MatchStateManager(),
                new AdvanceScoreManager(),
                random);

            matchSimulator.OnMatchEnded += HandleMatchEnded;

            matchSimulator.SimulateMatch();
        }

        private void HandleMatchEnded(object? sender, MatchScoreEventArgs e)
        {
            tournamentScoreManager.AddMatchScore(e.MatchScore);

            DetermineNextTournamentBracket();
        }

        private void TournamentEnded()
        {
            if (matchSimulator != null)
                matchSimulator.OnMatchEnded -= HandleMatchEnded;

            TournamentScoreEventArgs tournamentScoreEventArgs = new TournamentScoreEventArgs(
                tournamentScoreManager.TournamentScore);
            OnTournamentEnded?.Invoke(this, tournamentScoreEventArgs);

            Leaderboard leaderboard = leaderboardManager.UpdateLeaderboard(
                tournamentScoreManager.TournamentScore);

            LeaderboardEventArgs leaderboardEventArgs = new LeaderboardEventArgs(leaderboard);
            OnLeaderboardUpdated?.Invoke(this, leaderboardEventArgs);

            iTournamentBracketPrinter.PrintTournamentBracket(tournamentScoreManager.TournamentScore);
            iLeaderboardPrinter.PrintLeaderboard(leaderboard);
        }
    }
}
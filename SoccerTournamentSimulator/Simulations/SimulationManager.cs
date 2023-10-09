using SoccerTournamentSimulator.Simulations.Leaderboards;
using SoccerTournamentSimulator.Simulations.Matches.Scores;
using SoccerTournamentSimulator.Simulations.Pairings;
using SoccerTournamentSimulator.Simulations.Teams;
using SoccerTournamentSimulator.Simulations.Tournaments;

namespace SoccerTournamentSimulator.Simulations
{
    /// <summary>
    /// Manages the simulation.
    /// </summary>
    public class SimulationManager
    {
        private TournamentSimulator tournamentSimulator;

        public SimulationManager(ITeamDatabase teamDatabase)
        {
            tournamentSimulator = new TournamentSimulator(
                teamDatabase,
                new RoundRobinPairingsGenerator(),
                new TournamentScoreManager(),
                new LeaderboardManager(),
                new LeaderboardPrinter());

            tournamentSimulator.OnTournamentEnded += HandleTournamentEnded;
            tournamentSimulator.OnLeaderboardUpdated += HandleLeaderboardUpdated;
        }

        public void StartSimulation()
        {
            tournamentSimulator.SimulateTournament();
        }

        private void HandleTournamentEnded(object sender, TournamentScoreEventArgs e)
        {
            tournamentSimulator.OnTournamentEnded -= HandleTournamentEnded;
        }

        private void HandleLeaderboardUpdated(object sender, LeaderboardEventArgs e)
        {
            tournamentSimulator.OnLeaderboardUpdated -= HandleLeaderboardUpdated;
        }
    }
}
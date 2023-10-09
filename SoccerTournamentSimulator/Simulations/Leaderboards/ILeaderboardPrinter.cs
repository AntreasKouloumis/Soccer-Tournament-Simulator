namespace SoccerTournamentSimulator.Simulations.Leaderboards
{
    /// <summary>
    /// Leaderboard printer interface.
    /// </summary>
    public interface ILeaderboardPrinter
    {
        /// <summary>
        /// Prints a leaderboard in the console.
        /// </summary>
        /// <param name="leaderboard">Leaderboard to print.</param>
        void PrintLeaderboard(Leaderboard leaderboard);
    }
}
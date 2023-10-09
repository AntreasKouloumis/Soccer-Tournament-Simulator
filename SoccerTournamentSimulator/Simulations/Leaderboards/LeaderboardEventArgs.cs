namespace SoccerTournamentSimulator.Simulations.Leaderboards
{
    /// <summary>
    /// Leaderboard event arguments.
    /// </summary>
    public class LeaderboardEventArgs : EventArgs
    {
        public Leaderboard Leaderboard { get; }

        public LeaderboardEventArgs(Leaderboard leaderboard)
        {
            Leaderboard = leaderboard;
        }
    }
}